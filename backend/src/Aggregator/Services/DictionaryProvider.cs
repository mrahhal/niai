using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Services
{
	public interface IDictionaryProvider
	{
		Task<FileInfo> GetFileAsync(string dictionaryName);

		Task<List<FileInfo>> CollectFilesAsync(string dictionaryName, string fileNamePrefix);
	}

	public static class IDictionaryProviderExtensions
	{
		public static Task<List<FileInfo>> CollectKanjiFrequencyFilesAsync(this IDictionaryProvider dictionaryProvider) =>
			dictionaryProvider.CollectFilesAsync(DictionaryConstants.Names.Frequency, "kanji_meta_bank_");

		public static Task<List<FileInfo>> CollectVocabFrequencyFilesAsync(this IDictionaryProvider dictionaryProvider) =>
			dictionaryProvider.CollectFilesAsync(DictionaryConstants.Names.Frequency, "term_meta_bank_");

		public static Task<List<FileInfo>> CollectKanjiFilesAsync(this IDictionaryProvider dictionaryProvider) =>
			dictionaryProvider.CollectFilesAsync(DictionaryConstants.Names.Kanji, "kanji_bank_");

		public static Task<List<FileInfo>> CollectKanjiTagFilesAsync(this IDictionaryProvider dictionaryProvider) =>
			dictionaryProvider.CollectFilesAsync(DictionaryConstants.Names.Kanji, "tag_bank_");

		public static Task<List<FileInfo>> CollectVocabFilesAsync(this IDictionaryProvider dictionaryProvider) =>
			dictionaryProvider.CollectFilesAsync(DictionaryConstants.Names.Vocab, "term_bank_");

		public static Task<List<FileInfo>> CollectVocabTagFilesAsync(this IDictionaryProvider dictionaryProvider) =>
			dictionaryProvider.CollectFilesAsync(DictionaryConstants.Names.Vocab, "tag_bank_");

		public static Task<FileInfo> GetSimilarKeiseiFileAsync(this IDictionaryProvider dictionaryProvider) =>
			dictionaryProvider.GetFileAsync("from_keisei.json");
	}

	public class DictionaryProvider : IDictionaryProvider
	{
		private readonly string _dictionariesDirectory;

		public DictionaryProvider()
		{
			_dictionariesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "data/dictionaries");
		}

		public Task<FileInfo> GetFileAsync(string dictionaryName)
		{
			var dictionary = Path.Combine(_dictionariesDirectory, dictionaryName);

			return Task.FromResult(new FileInfo(dictionary));
		}

		public Task<List<FileInfo>> CollectFilesAsync(string dictionaryName, string fileNamePrefix)
		{
			var dictionaryDirectory = Path.Combine(_dictionariesDirectory, dictionaryName);

			var files = Directory.GetFiles(dictionaryDirectory)
				.Where(x => Path.GetFileName(x).StartsWith(fileNamePrefix) && x.EndsWith(".json"))
				.Select(x => new FileInfo(x))
				.ToList();

			return Task.FromResult(files);
		}
	}
}
