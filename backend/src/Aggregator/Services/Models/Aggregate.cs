using System.Collections.Generic;

namespace Aggregator.Services
{
	public class AggregateKanjiModel
	{
		public WaniKaniKanji WaniKaniKanji { get; set; }
		public KanjiModel KanjiModel { get; set; }
		public FrequencyModel FrequencyModel { get; set; }

		public int? WaniKaniLevel => WaniKaniKanji?.Level;
		public string Onyomi => KanjiModel.Onyomi;
		public string Kunyomi => KanjiModel.Kunyomi;
		public string ImportantReading => WaniKaniKanji?.ImportantReading;

		public string Kanji => KanjiModel.Kanji;
		public List<string> Meanings => KanjiModel.Meanings;
		public List<TagModel> Tags => KanjiModel.Tags;

		public int? Frequency => FrequencyModel?.Frequency;
	}

	public class AggregateVocabModel
	{
		public WaniKaniVocab WaniKaniVocab { get; set; }
		public VocabModel VocabModel { get; set; }
		public FrequencyModel FrequencyModel { get; set; }

		public int? WaniKaniLevel => WaniKaniVocab?.Level;
		public string Kana => VocabModel.Kana;

		public string Vocab => VocabModel.Vocab;
		public List<string> Meanings => VocabModel.Meanings;
		public List<TagModel> Tags => VocabModel.Tags;

		public int? Frequency => FrequencyModel?.Frequency;
	}

	public class AggregationResult
	{
		public List<AggregateKanjiModel> Kanjis { get; set; }
		public List<AggregateVocabModel> Vocabs { get; set; }
	}
}
