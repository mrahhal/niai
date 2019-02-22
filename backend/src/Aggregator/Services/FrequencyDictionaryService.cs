using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aggregator.Services
{
	public interface IFrequencyDictionaryService : ISetupService
	{
		SafeMap<FrequencyModel> Kanjis { get; }

		SafeMap<FrequencyModel> Vocabs { get; }
	}

	public class FrequencyDictionaryService : IFrequencyDictionaryService
	{
		private readonly IDictionaryProvider _dictionaryProvider;

		public FrequencyDictionaryService(
			IDictionaryProvider dictionaryProvider)
		{
			_dictionaryProvider = dictionaryProvider;
		}

		public SafeMap<FrequencyModel> Kanjis { get; private set; }

		public SafeMap<FrequencyModel> Vocabs { get; private set; }

		public async Task SetupAsync()
		{
			var kanjiFiles = await _dictionaryProvider.CollectKanjiFrequencyFilesAsync();
			var vocabFiles = await _dictionaryProvider.CollectVocabFrequencyFilesAsync();

			Kanjis = Process(kanjiFiles, false);
			Vocabs = Process(vocabFiles, true);
		}

		private SafeMap<FrequencyModel> Process(List<FileInfo> fileInfoes, bool skipSingleFrequency)
		{
			var serialzer = new JsonSerializer();
			var map = new SafeMap<FrequencyModel>();

			foreach (var fileInfo in fileInfoes)
			{
				using (var fs = fileInfo.OpenRead())
				using (var sr = new StreamReader(fs))
				using (var jtr = new JsonTextReader(sr))
				{
					var raw = serialzer.Deserialize<FrequencyModelRaw>(jtr);
					var models = raw.Select(l =>
					{
						return new FrequencyModel
						{
							Term = (string)l[0],
							Frequency = Convert.ToInt32(l[2]),
						};
					});

					foreach (var model in models.Where(x => !skipSingleFrequency || x.Frequency > 1))
					{
						map[model.Term] = model;
					}
				}
			}

			return map;
		}
	}
}
