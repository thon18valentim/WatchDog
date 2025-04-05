using System.Diagnostics;

namespace WatchDog.SentinelService.Linux
{
    public class ServiceChecker
    {
		private readonly string _prefix = "KartHub";
		private readonly List<string> _servicesToCheck = [];

		private void UpdateServicesToCheck()
		{
			_servicesToCheck.Clear();

			try
			{
				var process = new Process
				{
					StartInfo = new ProcessStartInfo
					{
						FileName = "/bin/bash",
						Arguments = $"-c \"systemctl list-units --type=service | grep {_prefix}\"",
						RedirectStandardOutput = true,
						RedirectStandardError = true,
						UseShellExecute = false,
						CreateNoWindow = true,
					}
				};

				process.Start();
				var result = process.StandardOutput.ReadToEnd();
				process.WaitForExit();

				foreach (var line in result.Split(Environment.NewLine))
				{
					if (!string.IsNullOrWhiteSpace(line))
					{
						var serviceName = line.Split(' ')[0].Trim();
						if (!string.IsNullOrEmpty(serviceName))
						{
							_servicesToCheck.Add(serviceName);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error on service list update: {ex.Message}");
			}
		}

		public void CheckServices()
		{
			foreach (var service in _servicesToCheck)
			{
				try
				{
					var process = new Process
					{
						StartInfo = new ProcessStartInfo
						{
							FileName = "/bin/bash",
							Arguments = $"-c \"systemctl is-active {service}\"",
							RedirectStandardOutput = true,
							RedirectStandardError = true,
							UseShellExecute = false,
							CreateNoWindow = true,
						}
					};

					process.Start();
					string result = process.StandardOutput.ReadToEnd().Trim();
					string error = process.StandardError.ReadToEnd().Trim();
					process.WaitForExit();

					if (string.IsNullOrEmpty(error))
					{
						Console.WriteLine($"Service: {service} - Status: {result}");
					}
					else
					{
						Console.WriteLine($"Service: {service} - Erro: {error}");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Verification error on service {service}: {ex.Message}");
				}
			}
		}

		public async Task StartMonitoringAsync()
		{
			while (true)
			{
				Console.WriteLine("Updating service list...");
				UpdateServicesToCheck();

				Console.WriteLine("Checking services...");
				CheckServices();

				await Task.Delay(TimeSpan.FromMinutes(5));
			}
		}
	}
}
