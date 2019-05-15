using System.Collections.Generic;

namespace Niai.Models.Dtos
{
	public class KanjiSummaryDto
	{
		public string Character { get; set; }

		public List<string> Meanings { get; set; }

		public string Onyomi { get; set; }

		public string Kunyomi { get; set; }

		public int? WaniKaniLevel { get; set; }

		public List<Tag> Tags { get; set; }

		public int? Frequency { get; set; }

		public int Strokes { get; set; }

		public int? Jlpt { get; set; }

		public int? Grade { get; set; }
	}

	public class KanjiSimilarDto : KanjiSummaryDto
	{
		public double Score { get; set; }
	}

	public class KanjiDto : KanjiSummaryDto
	{
		public List<KanjiSimilarDto> Similar { get; set; }
	}
}
