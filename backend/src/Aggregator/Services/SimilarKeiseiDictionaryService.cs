using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Niai;
using Niai.Models;

namespace Aggregator.Services
{
	public class SimilarKeiseiDictionaryService : ISimilarDictionaryService, ISetupService
	{
		private readonly IDictionaryProvider _dictionaryProvider;

		public SimilarKeiseiDictionaryService(
			IDictionaryProvider dictionaryProvider)
		{
			_dictionaryProvider = dictionaryProvider;
		}

		public SafeMap<List<SimilarKanji>> Model { get; private set; }

		public async Task SetupAsync()
		{
			var fileInfo = await _dictionaryProvider.GetSimilarKeiseiFileAsync();
			var serialzer = new JsonSerializer();

			using (var fs = fileInfo.OpenRead())
			using (var sr = new StreamReader(fs))
			using (var jtr = new JsonTextReader(sr))
			{
				var raw = serialzer.Deserialize<SimilarModelRaw>(jtr);

				Model = SafeMap<List<SimilarKanji>>.Create(raw, list => list.Select(x => new SimilarKanji
				{
					Value = x,
					Score = 0.65, // Default score for Keisei dictionary.
				}).ToList());
			}
		}
	}
}
