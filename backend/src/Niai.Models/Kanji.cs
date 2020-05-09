using System.Collections.Generic;
using System.Diagnostics;

namespace Niai.Models
{
	public class Kanji
	{
		public string Character { get; set; }

		public List<string> Meanings { get; set; }

		public string Onyomi { get; set; }

		public string Kunyomi { get; set; }

		public int? WaniKaniLevel { get; set; }

		public List<string> Tags { get; set; }

		public int? Frequency { get; set; }

		public int Strokes { get; set; }

		public int? Jlpt { get; set; }

		public int? Grade { get; set; }

		public List<SimilarKanji> Similar { get; set; }
	}

	[DebuggerDisplay("{Kanji,nq}: {Score,nq}")]
	public class SimilarKanji
	{
		public string Kanji { get; set; }

		/// <summary>
		/// Represents the score of matching. Higher score means more similarity.
		/// The score range is from 0 to 1.
		/// </summary>
		public double Score { get; set; }
	}
}
