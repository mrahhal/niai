using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Niai.Models;

namespace Aggregator.Services
{
	public interface IExportService
	{
		Task ExportAsync(AggregationResult result);
	}

	public class ExportService : IExportService
	{
		public async Task ExportAsync(AggregationResult result)
		{
			var kanjis = ConvertToStandardKanjiModel(result);
			var vocabs = ConvertToStandardVocabModel(result);
			var homonyms = ComputeHomonyms(vocabs);
			var synonyms = ComputeSynonyms(vocabs);
			var metadata = new Metadata
			{
				KanjiCount = kanjis.Count,
				VocabCount = vocabs.Count,
				HomonymCount = homonyms.Where(x => x.Value.Count > 1).Count(),
				SynonymCount = synonyms.Where(x => x.Value.Count > 1).Count(),
			};

			await WriteJsonFileAsync(kanjis, "kanjis");
			await WriteJsonFileAsync(vocabs, "vocabs");
			await WriteJsonFileAsync(homonyms, "homonyms");
			await WriteJsonFileAsync(synonyms, "synonyms");
			await WriteJsonFileAsync(metadata, "metadata");
		}

		private List<Kanji> ConvertToStandardKanjiModel(AggregationResult result)
		{
			return result.Kanjis.Select(x => new Kanji
			{
				Frequency = x.Frequency,
				Kunyomi = x.Kunyomi,
				Meanings = x.Meanings,
				Onyomi = x.Onyomi,
				Tags = CreateTags(x.Tags),
				Character = x.Kanji,
				WaniKaniLevel = x.WaniKaniLevel,
				Similar = x.Similar,
				Grade = x.KanjiModel.Grade,
				Jlpt = x.KanjiModel.Jlpt,
				Strokes = x.KanjiModel.Strokes,
			}).OrderBy(x => x.Character).ToList();
		}

		private List<Vocab> ConvertToStandardVocabModel(AggregationResult result)
		{
			return result.Vocabs.Select(x => new Vocab
			{
				Frequency = x.Frequency,
				Kana = x.Kana == "" ? x.Vocab : x.Kana,
				Kanji = x.Vocab == "〃" ? x.Kana : x.Vocab,
				Meanings = x.Meanings,
				Tags = CreateTags(x.Tags),
			}).OrderBy(x => x.Kana).ThenBy(x => x.Frequency).ToList();
		}

		private List<Tag> CreateTags(List<TagModel> tagModels)
		{
			return tagModels
				.Distinct(TagModelEqualityComparer.Instance)
				.OrderBy(t => t.Order)
				.Select(t => new Tag { Key = t.Key, Value = t.Value })
				.ToList();
		}

		private Dictionary<string, List<string>> ComputeHomonyms(List<Vocab> vocabs)
		{
			var homonyms = vocabs.GroupBy(v => v.Kana)
				.Select(g => new { Reading = g.Key, Items = g.Select(x => x.Kanji).OrderBy(x => x).ToList() })
				.ToDictionary(x => x.Reading, x => x.Items);

			return homonyms;
		}

		private Dictionary<string, List<string>> ComputeSynonyms(List<Vocab> vocabs)
		{
			var map = new Dictionary<string, List<string>>();

			foreach (var vocab in vocabs)
			{
				foreach (var meaning in vocab.Meanings)
				{
					var list = default(List<string>);

					if (map.ContainsKey(meaning))
					{
						list = map[meaning];
					}
					else
					{
						list = new List<string>();
						map[meaning] = list;
					}

					list.Add(vocab.Kanji);
				}
			}

			return map;
		}

		private static async Task WriteJsonFileAsync(object obj, string name)
		{
			var directory = Directory.GetCurrentDirectory();
			var filePath = Path.Combine(directory, $"../Niai/data/{name}.json");
			Directory.CreateDirectory(Path.GetDirectoryName(filePath));

			var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
			await File.WriteAllTextAsync(filePath, json);
		}
	}
}
