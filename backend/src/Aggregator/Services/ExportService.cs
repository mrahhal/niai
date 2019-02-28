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
			var metadata = new Metadata
			{
				KanjiCount = kanjis.Count,
				VocabCount = vocabs.Count,
			};

			await WriteJsonFileAsync(kanjis, "kanjis");
			await WriteJsonFileAsync(vocabs, "vocabs");
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
				Tags = x.Tags.Select(t => new Tag { Key = t.Key, Value = t.Value }).ToList(),
				Character = x.Kanji,
				WaniKaniLevel = x.WaniKaniLevel,
				Similar = x.Similar,
				Grade = x.KanjiModel.Grade,
				Jlpt = x.KanjiModel.Jlpt,
				Strokes = x.KanjiModel.Strokes,
			}).ToList();
		}

		private List<Vocab> ConvertToStandardVocabModel(AggregationResult result)
		{
			return result.Vocabs.Select(x => new Vocab
			{
				Frequency = x.Frequency,
				Kana = x.Kana == "" ? x.Vocab : x.Kana,
				Kanji = x.Vocab == "〃" ? x.Kana : x.Vocab,
				Meanings = x.Meanings,
				Tags = x.Tags.Select(t => new Tag { Key = t.Key, Value = t.Value }).ToList(),
			}).ToList();
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
