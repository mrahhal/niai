using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Aggregator.Helpers;
using Niai;

namespace Aggregator.Services
{
	public interface IVocabDictionaryService : ISetupService
	{
		SafeMap<TagModel> Tags { get; }

		SafeMap<VocabModel> Vocabs { get; }
	}

	public class VocabDictionaryService : TagDictionaryServiceBase, IVocabDictionaryService
	{
		private readonly IDictionaryProvider _dictionaryProvider;

		public VocabDictionaryService(
			IDictionaryProvider dictionaryProvider)
		{
			_dictionaryProvider = dictionaryProvider;
		}

		public SafeMap<VocabModel> Vocabs { get; private set; }

		public async Task SetupAsync()
		{
			var tagFiles = await _dictionaryProvider.CollectVocabTagFilesAsync();
			ProcessTagBanks(tagFiles);

			AddExtraTags();

			var vocabFiles = await _dictionaryProvider.CollectVocabFilesAsync();
			Vocabs = ProcessVocabBanks(vocabFiles);
		}

		private void AddExtraTags()
		{
			// Add extra tags such as "v5"...

			var extraTags = new List<TagModel>
			{
				CreateExtraTag("v5", "Godan verb")
			};

			foreach (var tag in extraTags)
			{
				if (!Tags.ContainsKey(tag.Key))
				{
					Tags[tag.Key] = tag;
				}
			}

			TagModel CreateExtraTag(string key, string value)
			{
				return new TagModel
				{
					Key = key,
					Value = value,
					IsExtra = true,
				};
			}
		}

		private SafeMap<VocabModel> ProcessVocabBanks(List<FileInfo> fileInfoes)
		{
			var serialzer = new JsonSerializer();
			var map = new SafeMap<VocabModel>();

			foreach (var fileInfo in fileInfoes)
			{
				using (var fs = fileInfo.OpenRead())
				using (var sr = new StreamReader(fs))
				using (var jtr = new JsonTextReader(sr))
				{
					var raw = serialzer.Deserialize<VocabModelRaw>(jtr);
					var models = raw.Select(l =>
					{
						var tags = (string)l[2];
						var tags2 = (string)l[3];
						var tagModels = TagHelper.SplitTags(tags, tags2).Select(x =>
						{
							if (Tags.TryGetValue(x, out var tagModel))
							{
								return tagModel;
							}
							return null;
						}).Where(x => x != null).ToList();

						var meanings = ((JArray)l[5]).ToObject<List<string>>();

						return new VocabModel
						{
							Vocab = (string)l[0],
							Kana = (string)l[1],
							Tags = tagModels,
							Meanings = meanings,
						};
					});

					foreach (var model in models)
					{
						map[model.Vocab] = model;
					}
				}
			}

			return map;
		}
	}
}
