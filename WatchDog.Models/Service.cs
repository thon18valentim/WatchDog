namespace WatchDog.Models
{
	public class Service
	{
		public required string Name { get; set; }
		public required string Env { get; set; }
		public required ServiceStatus Status { get; set; }
	}
}
