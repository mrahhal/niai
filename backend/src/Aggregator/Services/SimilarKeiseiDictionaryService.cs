using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aggregator.Services
{
	public interface ISimilarKeiseiDictionaryService : ISetupService
	{
		SafeMap<List<string>> Model { get; }
	}

	public class SimilarKeiseiDictionaryService : ISimilarKeiseiDictionaryService
	{

		private readonly IDictionaryProvider _dictionaryProvider;

		public SimilarKeiseiDictionaryService(
			IDictionaryProvider dictionaryProvider)
		{
			_dictionaryProvider = dictionaryProvider;
		}

		public SafeMap<List<string>> Model { get; private set; }

		public async Task SetupAsync()
		{
			var fileInfo = await _dictionaryProvider.GetSimilarKeiseiFileAsync();
			var serialzer = new JsonSerializer();

			using (var fs = fileInfo.OpenRead())
			using (var sr = new StreamReader(fs))
			using (var jtr = new JsonTextReader(sr))
			{
				var raw = serialzer.Deserialize<SimilarModelRaw>(jtr);
				Model = raw.ToSafeMap();
			}
		}
	}
}
