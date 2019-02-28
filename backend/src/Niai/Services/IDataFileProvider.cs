using System.Threading.Tasks;

namespace Niai.Services
{
	public interface IDataFileProvider
	{
		Task<string> GetContentsAsync(string name);
	}

	public static class DataFileProviderExtensions
	{
		public static Task<string> GetKanjisContentsAsync(this IDataFileProvider @this) =>
			@this.GetContentsAsync("kanjis");

		public static Task<string> GetVocabsContentsAsync(this IDataFileProvider @this) =>
			@this.GetContentsAsync("vocabs");

		public static Task<string> GetHomonymsContentsAsync(this IDataFileProvider @this) =>
			@this.GetContentsAsync("homonyms");

		public static Task<string> GetSynonymsContentsAsync(this IDataFileProvider @this) =>
			@this.GetContentsAsync("synonyms");

		public static Task<string> GetMetadataContentsAsync(this IDataFileProvider @this) =>
			@this.GetContentsAsync("metadata");
	}
}
