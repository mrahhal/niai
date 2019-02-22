using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Services
{
	public interface IWaniKaniDictionaryService
	{
		SafeMap<WaniKaniKanji> Kanjis { get; }

		SafeMap<WaniKaniVocab> Vocabs { get; }

		List<WaniKaniVocab> IgnoredVocabs { get; }
	}

	public class WaniKaniDictionaryService : IWaniKaniDictionaryService, ISetupService
	{
		private readonly IWaniKaniService _waniKaniService;
		private readonly IVocabDictionaryService _vocabDictionaryService;

		public WaniKaniDictionaryService(
			IWaniKaniService waniKaniService,
			IVocabDictionaryService vocabDictionaryService)
		{
			_waniKaniService = waniKaniService;
			_vocabDictionaryService = vocabDictionaryService;
		}

		public SafeMap<WaniKaniKanji> Kanjis { get; private set; }

		public SafeMap<WaniKaniVocab> Vocabs { get; private set; }

		public List<WaniKaniVocab> IgnoredVocabs { get; private set; }

		public async Task SetupAsync()
		{
			var kanjisTask = _waniKaniService.GetKanjisAsync();
			var vocabsTask = _waniKaniService.GetVocabsAsync();

			await Task.WhenAll(kanjisTask, vocabsTask);

			Kanjis = kanjisTask.Result.RequestedInformation.ToSafeMap(x => x.Character);

			var (Filtered, Ignored) = FilterVocabs(vocabsTask.Result.RequestedInformation.General);
			Vocabs = Filtered;
			IgnoredVocabs = Ignored;
		}

		private (SafeMap<WaniKaniVocab> Filtered, List<WaniKaniVocab> Ignored) FilterVocabs(List<WaniKaniVocab> vocabs)
		{
			var ignored = new List<WaniKaniVocab>();

			var filtered = vocabs.Where(vocab =>
			{
				if (!_vocabDictionaryService.Vocabs.TryGetValue(vocab.Character, out var vocabModel))
				{
					ignored.Add(vocab);
					return false;
				}

				return true;
			}).ToSafeMap(x => x.Character);

			return (filtered, ignored);
		}
	}
}
