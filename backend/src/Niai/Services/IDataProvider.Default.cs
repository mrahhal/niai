using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MR.AttributeDI;
using Newtonsoft.Json;
using Niai.Models;

namespace Niai.Services
{
	[AddToServices(Lifetime.Singleton, As = typeof(IDataProvider))]
	[AddToServices(Lifetime.Singleton, As = typeof(ISetupService), ForwardTo = typeof(IDataProvider))]
	public class DataProvider : IDataProvider, ISetupService
	{
		private readonly IDataFileProvider _dataFileProvider;

		public DataProvider(
			IDataFileProvider dataFileProvider)
		{
			_dataFileProvider = dataFileProvider;
		}

		public Dictionary<string, Kanji> Kanjis { get; private set; }

		public Metadata Metadata { get; private set; }

		public async Task SetupAsync()
		{
			var kanjisJson = await _dataFileProvider.GetKanjisContentsAsync();
			var kanjis = JsonConvert.DeserializeObject<List<Kanji>>(kanjisJson);
			Kanjis = kanjis.ToDictionary(x => x.Character);

			var metadataJson = await _dataFileProvider.GetMetadataContentsAsync();
			Metadata = JsonConvert.DeserializeObject<Metadata>(metadataJson);
		}
	}
}
