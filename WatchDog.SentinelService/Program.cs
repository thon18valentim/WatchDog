
namespace WatchDog.SentinelService
{
	class Program
	{
		static async Task Main()
		{
			var serviceChecker = new ServiceChecker();
			await serviceChecker.StartMonitoringAsync();
		}
	}
}
