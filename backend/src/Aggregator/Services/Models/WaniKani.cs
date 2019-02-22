using System.Collections.Generic;

namespace Aggregator.Services
{
	public class WaniKaniUserInformation
	{
		public int Level { get; set; }
		public string Title { get; set; }
		public string Username { get; set; }
	}

	public class WaniKaniVocab
	{
		public int Level { get; set; }
		public string Character { get; set; }
		public string Kana { get; set; }
		public string Meaning { get; set; }
	}

	public class WaniKaniVocabModelRequestedInformation
	{
		public List<WaniKaniVocab> General { get; set; }
	}

	public class WaniKaniVocabModel
	{
		public WaniKaniUserInformation UserInformation { get; set; }
		public WaniKaniVocabModelRequestedInformation RequestedInformation { get; set; }
	}

	public class WaniKaniKanji
	{
		public int Level { get; set; }
		public string Character { get; set; }
		public string Meaning { get; set; }
		public string Onyomi { get; set; }
		public string Kunyomi { get; set; }
		public string ImportantReading { get; set; }
		public string Nanori { get; set; }
	}

	public class WaniKaniKanjiModel
	{
		public WaniKaniUserInformation UserInformation { get; set; }
		public List<WaniKaniKanji> RequestedInformation { get; set; }
	}
}
