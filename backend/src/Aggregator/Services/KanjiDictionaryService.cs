using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Aggregator.Helpers;

namespace Aggregator.Services
{
	public interface IKanjiDictionaryService : ISetupService
	{
		SafeMap<TagModel> Tags { get; }

		SafeMap<KanjiModel> Kanjis { get; }
	}

	public class KanjiDictionaryService : TagDictionaryServiceBase, IKanjiDictionaryService
	{
		private readonly IDictionaryProvider _dictionaryProvider;

		public KanjiDictionaryService(
			IDictionaryProvider dictionaryProvider)
		{
			_dictionaryProvider = dictionaryProvider;
		}

		public SafeMap<KanjiModel> Kanjis { get; private set; }

		public async Task SetupAsync()
		{
			var tagFiles = await _dictionaryProvider.CollectKanjiTagFilesAsync();
			ProcessTagBanks(tagFiles);

			var kanjiFiles = await _dictionaryProvider.CollectKanjiFilesAsync();
			Kanjis = ProcessKanjiBanks(kanjiFiles);
		}

		private SafeMap<KanjiModel> ProcessKanjiBanks(List<FileInfo> fileInfoes)
		{
			var serialzer = new JsonSerializer();
			var map = new SafeMap<KanjiModel>();

			foreach (var fileInfo in fileInfoes)
			{
				using (var fs = fileInfo.OpenRead())
				using (var sr = new StreamReader(fs))
				using (var jtr = new JsonTextReader(sr))
				{
					var raw = serialzer.Deserialize<KanjiModelRaw>(jtr);
					var models = raw.Select(l =>
					{
						var tags = (string)l[3];
						var tagModels = TagHelper.SplitTags(tags).Select(x =>
						{
							if (Tags.TryGetValue(x, out var tagModel))
							{
								return tagModel;
							}
							return null;
						}).Where(x => x != null).ToList();

						var meanings = ((JArray)l[4]).ToObject<List<string>>();

						return new KanjiModel
						{
							Kanji = (string)l[0],
							Onyomi = (string)l[1],
							Kunyomi = (string)l[2],
							Tags = tagModels,
							Meanings = meanings,
						};
					});

					foreach (var model in models)
					{
						map[model.Kanji] = model;
					}
				}
			}

			return map;
		}
	}
}
