using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.Services
{
	public interface IAggregatorService
	{
		Task<AggregationResult> AggregateDataAsync();
	}

	public class AggregatorService : IAggregatorService
	{
		private readonly IWaniKaniDictionaryService _waniKaniDictionaryService;
		private readonly IFrequencyDictionaryService _frequencyDictionaryService;
		private readonly IKanjiDictionaryService _kanjiDictionaryService;
		private readonly IVocabDictionaryService _vocabDictionaryService;

		public AggregatorService(
			IWaniKaniDictionaryService waniKaniDictionaryService,
			IFrequencyDictionaryService frequencyDictionaryService,
			IKanjiDictionaryService kanjiDictionaryService,
			IVocabDictionaryService vocabDictionaryService)
		{
			_waniKaniDictionaryService = waniKaniDictionaryService;
			_frequencyDictionaryService = frequencyDictionaryService;
			_kanjiDictionaryService = kanjiDictionaryService;
			_vocabDictionaryService = vocabDictionaryService;
		}

		public async Task<AggregationResult> AggregateDataAsync()
		{
			var kTask = AggregateKanjiAsync();
			var vTask = AggregateVocabAsync();

			await Task.WhenAll(kTask, vTask);

			return new AggregationResult
			{
				Kanjis = kTask.Result,
				Vocabs = vTask.Result,
			};
		}

		private Task<List<AggregateKanjiModel>> AggregateKanjiAsync()
		{
			var kanjis = _kanjiDictionaryService.Kanjis;

			return Task.FromResult(kanjis.AsParallel()
				.Select(kanji =>
				{
					var character = kanji.Key;
					var waniKaniKanji = _waniKaniDictionaryService.Kanjis[character];
					var frequencyModel = _frequencyDictionaryService.Kanjis[character];

					return new AggregateKanjiModel
					{
						WaniKaniKanji = waniKaniKanji,
						FrequencyModel = frequencyModel,
						KanjiModel = kanji.Value,
					};
				})
				.ToList());
		}

		private Task<List<AggregateVocabModel>> AggregateVocabAsync()
		{
			var vocabs = _vocabDictionaryService.Vocabs;

			return Task.FromResult(vocabs.AsParallel()
				.Select(vocab =>
				{
					var character = vocab.Key;
					var waniKaniVocabModel = _waniKaniDictionaryService.Vocabs[character];
					var frequencyModel = _frequencyDictionaryService.Vocabs[character];

					return new AggregateVocabModel
					{
						WaniKaniVocab = waniKaniVocabModel,
						FrequencyModel = frequencyModel,
						VocabModel = vocab.Value,
					};
				})
				.ToList());
		}
	}
}
