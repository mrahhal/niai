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
			var standardModels = ConvertToStandardKanjiModel(result);
			var directory = Directory.GetCurrentDirectory();
			var filePath = Path.Combine(directory, "../Niai/data/kanjis.json");
			Directory.CreateDirectory(Path.GetDirectoryName(filePath));

			var json = JsonConvert.SerializeObject(standardModels, Formatting.Indented);
			await File.WriteAllTextAsync(filePath, json);
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
				//Similar =
			}).ToList();
		}
	}
}
