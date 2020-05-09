using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Aggregator.Services;
using Autofac;

namespace Aggregator
{
	public class Program
	{
		private readonly IEnumerable<ISetupService> _setupServices;
		private readonly IAggregatorService _aggregatorService;
		private readonly IExportService _exportService;

		private static Task Main()
		{
			return ContainerAccessor.Container.Resolve<Program>().RunAsync();
		}

		public Program(
			IEnumerable<ISetupService> setupServices,
			IAggregatorService aggregatorService,
			IExportService exportService)
		{
			_setupServices = setupServices;
			_aggregatorService = aggregatorService;
			_exportService = exportService;
		}

		public async Task RunAsync()
		{
			Console.WriteLine("Preparing...");
			var swg = Stopwatch.StartNew();
			var sw = Stopwatch.StartNew();

			await Task.WhenAll(_setupServices.Select(s => s.SetupAsync()));

			Console.WriteLine($"Preparing finished: {sw.Elapsed.TotalSeconds} sec");

			Console.WriteLine("Aggregating data...");
			sw.Restart();

			var aggregationResult = await _aggregatorService.AggregateDataAsync();

			Console.WriteLine($"Aggregating data finished: {sw.Elapsed.TotalSeconds} sec");

			Console.WriteLine("Exporting...");
			sw.Restart();

			await _exportService.ExportAsync(aggregationResult);

			Console.WriteLine($"Exporting finished: {sw.Elapsed.TotalSeconds} sec");
			Console.WriteLine($"Took {swg.Elapsed.TotalSeconds} sec");
		}
	}
}
