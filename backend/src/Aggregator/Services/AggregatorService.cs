using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Niai.Models;

namespace Aggregator.Services
{
	public interface IAggregatorService
	{
		Task<AggregationResult> AggregateDataAsync();
	}

	public class AggregatorService : IAggregatorService
	{
		private const double MinimumScore = 0.5;

		private readonly IWaniKaniDictionaryService _waniKaniDictionaryService;
		private readonly IFrequencyDictionaryService _frequencyDictionaryService;
		private readonly IKanjiDictionaryService _kanjiDictionaryService;
		private readonly IVocabDictionaryService _vocabDictionaryService;
		private readonly List<ISimilarDictionaryService> _similarDictionaryServices;

		public AggregatorService(
			IWaniKaniDictionaryService waniKaniDictionaryService,
			IFrequencyDictionaryService frequencyDictionaryService,
			IKanjiDictionaryService kanjiDictionaryService,
			IVocabDictionaryService vocabDictionaryService,
			IEnumerable<ISimilarDictionaryService> similarDictionaryServices)
		{
			_waniKaniDictionaryService = waniKaniDictionaryService;
			_frequencyDictionaryService = frequencyDictionaryService;
			_kanjiDictionaryService = kanjiDictionaryService;
			_vocabDictionaryService = vocabDictionaryService;
			_similarDictionaryServices = similarDictionaryServices.ToList();
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
				KanjiTags = _kanjiDictionaryService.Tags,
				VocabTags = _vocabDictionaryService.Tags,
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

					var allSimilarKanjiModels = _similarDictionaryServices
						.Where(x => x.Model.ContainsKey(character))
						.SelectMany(x => x.Model[character])
						.ToList();
					var allSimilarValues = allSimilarKanjiModels
						.Select(x => x.Value)
						.Distinct()
						.ToList();
					var similarValues = allSimilarValues
						.Select(value => ElectBestCandidate(value, allSimilarKanjiModels))
						.Where(x => x.Score > MinimumScore)
						.OrderByDescending(x => x.Score)
						.ToList();

					return new AggregateKanjiModel
					{
						WaniKaniKanji = waniKaniKanji,
						FrequencyModel = frequencyModel,
						KanjiModel = kanji.Value,
						Similar = similarValues,
					};
				})
				.ToList());
		}

		private SimilarKanji ElectBestCandidate(string value, List<SimilarKanji> similarKanjis)
		{
			return similarKanjis
				.Where(x => x.Value == value)
				.OrderByDescending(x => x.Score)
				.First();
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
