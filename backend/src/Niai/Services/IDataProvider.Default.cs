using System.Collections.Generic;
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

		public SafeMap<Kanji> Kanjis { get; private set; }

		public SafeMap<Vocab> Vocabs { get; private set; }

		public SafeMap<List<string>> Homonyms { get; private set; }

		public SafeMap<List<string>> Synonyms { get; private set; }

		public Metadata Metadata { get; private set; }

		public async Task SetupAsync()
		{
			var kanjisJson = await _dataFileProvider.GetKanjisContentsAsync();
			var kanjis = JsonConvert.DeserializeObject<List<Kanji>>(kanjisJson);
			Kanjis = kanjis.ToSafeMap(x => x.Character);

			var vocabsJson = await _dataFileProvider.GetVocabsContentsAsync();
			var vocabs = JsonConvert.DeserializeObject<List<Vocab>>(vocabsJson);
			Vocabs = vocabs.ToSafeMap(x => x.Kanji);

			var homonymsJson = await _dataFileProvider.GetHomonymsContentsAsync();
			var homonyms = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(homonymsJson);
			Homonyms = homonyms.ToSafeMap();

			var synonymsJson = await _dataFileProvider.GetSynonymsContentsAsync();
			var synonyms = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(synonymsJson);
			Synonyms = synonyms.ToSafeMap();

			var metadataJson = await _dataFileProvider.GetMetadataContentsAsync();
			Metadata = JsonConvert.DeserializeObject<Metadata>(metadataJson);
		}
	}
}
