using System.Collections.Generic;
using System.Diagnostics;

namespace Aggregator.Services
{
	[DebuggerDisplay("{Kanji,nq}")]
	public class KanjiModel
	{
		public string Kanji { get; set; }
		public string Onyomi { get; set; }
		public string Kunyomi { get; set; }
		public List<string> Meanings { get; set; }
		public List<TagModel> Tags { get; set; }
		public int Strokes { get; set; }
		public int? Jlpt { get; set; }
		public int? Grade { get; set; }
	}

	public class KanjiModelRaw : List<List<object>>
	{
	}
}
