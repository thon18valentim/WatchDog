using System.Net.WebSockets;
using System.Net;
using System.Text;

Console.WriteLine("\nWebSocket server starting...\n");

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls(builder.Configuration["Host"]!);

var app = builder.Build();
app.UseWebSockets();

var connections = new List<WebSocket>();

app.Map("/ws", async context =>
{
	if (context.WebSockets.IsWebSocketRequest)
	{
		var curName = context.Request.Query["name"];
		var accessKey = context.Request.Query["accessKey"];

		var serverAccessKey = builder.Configuration["AccessKey"];
		if (accessKey != serverAccessKey)
		{
			return;
		}

		using var ws = await context.WebSockets.AcceptWebSocketAsync();
		connections.Add(ws);

		await Broadcast($"{curName} joined the room");
		await Broadcast($"{connections.Count} users connected");

		await ReceiveMessage(ws,
			async (result, buffer) =>
			{
				if (result.MessageType is WebSocketMessageType.Text)
				{
					try
					{
						var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
						await Broadcast(curName + ": " + message);
					}
					catch (Exception ex)
					{
						await Broadcast($"{curName} message error: {ex.Message}");
						Console.WriteLine(ex);
					}
				}
				else if (result.MessageType == WebSocketMessageType.Close || ws.State == WebSocketState.Aborted)
				{
					connections.Remove(ws);
					await Broadcast($"{curName} left the room");
					await Broadcast($"{connections.Count} users connected");
					await ws.CloseAsync(result.CloseStatus!.Value, result.CloseStatusDescription, CancellationToken.None);
				}
			});
	}
	else
	{
		context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
	}
});

async Task ReceiveMessage(WebSocket webSocket, Action<WebSocketReceiveResult, byte[]> handleMessage)
{
	var buffer = new byte[1024 * 4];
	while (webSocket.State is WebSocketState.Open)
	{
		try
		{
			var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
			handleMessage(result, buffer);
		}
		catch
		{
			RemoveConnection(webSocket);
		}
	}
}

async Task Broadcast(string message)
{
	var bytes = Encoding.UTF8.GetBytes(message);
	lock (connections)
	{
		connections = [.. connections.Where(socket => socket.State == WebSocketState.Open)];
	}

	foreach (var socket in connections.ToList())
	{
		try
		{
			var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
			await socket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
		}
		catch
		{
			RemoveConnection(socket);
		}
	}
}

void RemoveConnection(WebSocket ws)
{
	lock (connections)
	{
		connections.Remove(ws);
	}
}

await app.RunAsync();