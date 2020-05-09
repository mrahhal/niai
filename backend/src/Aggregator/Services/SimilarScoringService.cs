using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Niai;
using Niai.Models;

namespace Aggregator.Services
{
	public interface ISimilarScoringService
	{
		Task<SafeMap<List<SimilarKanji>>> ScoreAsync();
	}

	public class SimilarScoringService : ISimilarScoringService
	{
		private SafeMap<List<SimilarKanji>> _model;

		private readonly IKradFileProvider _kradFileProvider;
		private readonly INiaiFileProvider _niaiFileProvider;
		private readonly IKanjiDictionaryService _kanjiDictionaryService;

		public SimilarScoringService(
			IKradFileProvider kradFileProvider,
			INiaiFileProvider niaiFileProvider,
			IKanjiDictionaryService kanjiDictionaryService)
		{
			_kradFileProvider = kradFileProvider;
			_niaiFileProvider = niaiFileProvider;
			_kanjiDictionaryService = kanjiDictionaryService;
		}

		public async Task<SafeMap<List<SimilarKanji>>> ScoreAsync()
		{
			if (_model != null)
			{
				return _model;
			}

			await ScoreCoreAsync();

			return _model;
		}

		/// <summary>
		/// Scores all similar kanjis of all models.
		/// How we score: percentage of shared radicals over the max of the total number of radicals.
		///	This helps create distance between 2 similar kanjis having same number
		///	of shared radicals but one is more complex than the other (i.e has more non-shared radicals).
		/// </summary>
		public Task ScoreCoreAsync()
		{
			var p = _kradFileProvider;
			var model = new SafeMap<List<SimilarKanji>>();
			var processedMap = new SafeMap<SafeMap<bool>>();

			// Score

			List<SimilarKanji> GetSimilarList(string kanji)
			{
				if (!model.TryGetValue(kanji, out var list))
				{
					list = model[kanji] = new List<SimilarKanji>();
				}
				return list;
			}

			var minScore = 0.0;
			var maxScore = 0.0;

			void TrackScore(double score)
			{
				minScore = Math.Min(minScore, score);
				maxScore = Math.Max(maxScore, score);
			}

			double ComputeScore(string k1, string k2)
			{
				//var weightRadicalSimilar = 0.1;
				var weightStrokes = 0.1;

				var k1Radicals = p.Model[k1].Radicals;
				var k2Radicals = p.Model[k2].Radicals;

				var sharedRadicalCount = k1Radicals.Count(r => k2Radicals.Contains(r));
				var totalRadicalCount = Math.Max(k1Radicals.Count, k2Radicals.Count);
				//var totalRadicalCount = k1Radicals.Count + k2Radicals.Count;

				var score = (double)sharedRadicalCount / totalRadicalCount;

				// This won't work without taking into account the places of the radicals.
				//foreach (var r1 in k1Radicals)
				//{
				//	foreach (var r2 in k2Radicals.Where(r2 => r2 != r1))
				//	{
				//		var similar = _niaiFileProvider.SimilarRadicals[r1]
				//			?.Similar
				//			.FirstOrDefault(x => x.Radical == r2);
				//		if (similar == null) continue;

				//		score += similar.Value.Score * weightRadicalSimilar;
				//	}
				//}

				var k1Strokes = _kanjiDictionaryService.Kanjis[k1].Strokes;
				var k2Strokes = _kanjiDictionaryService.Kanjis[k2].Strokes;
				score += ((double)Math.Min(k1Strokes, k2Strokes) / Math.Max(k1Strokes, k2Strokes)) * weightStrokes;

				return score;
			}

			void ProcessPair(string k1, string k2)
			{
				if (processedMap.ContainsKey(k2))
				{
					// The potential similar kanji was already processed, this means
					// this pair was already processed.
					return;
				}

				if (!processedMap.TryGetValue(k1, out var innerMap))
				{
					innerMap = processedMap[k1] = new SafeMap<bool>();
				}
				if (innerMap.ContainsKey(k2))
				{
					return;
				}

				var score = ComputeScore(k1, k2);

				TrackScore(score);

				var similarList1 = GetSimilarList(k1);
				var similarList2 = GetSimilarList(k2);

				similarList1.Add(new SimilarKanji
				{
					Kanji = k2,
					Score = score,
				});
				similarList2.Add(new SimilarKanji
				{
					Kanji = k1,
					Score = score,
				});

				innerMap[k2] = true;
			}

			foreach (var e in p.Model.Values)
			{
				var radicals = e.Radicals;
				foreach (var radical in radicals)
				{
					var radicalKanjis = p.InverseModel[radical].Kanjis;
					foreach (var potentialSimilar in radicalKanjis)
					{
						if (potentialSimilar == e.Kanji)
						{
							continue;
						}
						ProcessPair(e.Kanji, potentialSimilar);
					}
				}
			}

			// Translate scores. Make sure scores are always between 0 and 1
			// even no matter what the scoring logic does.
			foreach (var m in model.Values.SelectMany(x => x))
			{
				var score = m.Score;
				m.Score = (score - minScore) / (maxScore - minScore);
			}

			foreach (var m in model.ToList())
			{
				// Sort and remove below minimum
				model[m.Key] = m.Value
					.OrderByDescending(x => x.Score)
					.Take(20)
					.ToList();
			}

			_model = model;

			WriteScoreSampleFile();

			return Task.CompletedTask;
		}

		private void WriteScoreSampleFile()
		{
			var sampleCharacters = new[]
			{
				"上", "辛", "岸", "高", "天", "乗", "物", "横", "谷", "料", "私", "是", "米", "能", "念",
				"正", "勢", "拾", "緑", "練", "象", "感", "獲", "受", "句", "試", "援"
			};

			var contents = "";

			foreach (var c in sampleCharacters)
			{
				var m = _model[c];
				var similarText = string.Join(" ", m.Select(x => x.Kanji));
				contents += $"{c}: {similarText}\n";
			}

			File.WriteAllText("sample-score.txt", contents);
		}
	}
}
