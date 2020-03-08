using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Niai.Services;

namespace Niai
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			var setupServices = host.Services.GetService<IEnumerable<ISetupService>>();
			await Task.WhenAll(setupServices.Select(service => service.SetupAsync()));

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
