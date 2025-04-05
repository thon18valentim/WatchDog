
namespace WatchDog.SentinelService.Linux
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
