
namespace WatchDog.Models
{
    public class WebSocketMessage
    {
		public required string ServiceName { get; set; }
		public required string Message { get; set; }
		public DateTime SendTime { get; set; }
	}
}
