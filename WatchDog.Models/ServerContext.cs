using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;

namespace WatchDog.Models
{
    public class ServerContext
    {
		private readonly string _serverUrl;
		private ClientWebSocket _webSocket;

		public ServerContext(string route, string accessKey, string name = "WatchDogMonitor")
		{
			_serverUrl = $"{route}?name={name}&accessKey={accessKey}";
			_webSocket = new ClientWebSocket();

			Connect().Wait();
		}

		public async Task StartService(string serviceName)
		{
			var message = new WebSocketMessage
			{
				ServiceName = serviceName,
				Message = "monitor-start-service",
				SendTime = DateTime.UtcNow
			};
			await SendMessage(JsonConvert.SerializeObject(message));
		}

		private async Task Connect(int reconnectTentives = 3, int delay = 3000)
		{
			var error = string.Empty;
			var tentatives = 0;

			while (_webSocket.State != WebSocketState.Open & tentatives < reconnectTentives)
			{
				try
				{
					_webSocket = new ClientWebSocket();
					await _webSocket.ConnectAsync(new Uri(_serverUrl), CancellationToken.None);

					return;
				}
				catch (Exception ex)
				{
					error = $"WebSocket connection error: {ex.Message}";
					Console.WriteLine(error);
					tentatives++;

					await Task.Delay(delay);
				}
			}

			throw new Exception(error);
		}

		private async Task SendMessage(string message)
		{
			if (_webSocket.State != WebSocketState.Open)
			{
				await Connect();
			}

			var bytes = Encoding.UTF8.GetBytes(message);
			try
			{
				await _webSocket.
					SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
			}
			catch (WebSocketException)
			{
				await Connect();
				await SendMessage(message);
			}
		}
	}
}
