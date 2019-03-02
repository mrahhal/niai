using System.Collections.Generic;
using System.Diagnostics;

namespace Aggregator.Services
{
	[DebuggerDisplay("{Kanji,nq}")]
	public class VocabModel
	{
		public string Kanji { get; set; }
		public List<VocabContextualMeaningModel> Meanings { get; set; } = new List<VocabContextualMeaningModel>();
	}

	public class VocabContextualMeaningModel
	{
		public string Kana { get; set; }
		public List<string> Meanings { get; set; }
		public List<TagModel> Tags { get; set; }
	}

	public class VocabModelRaw : List<List<object>>
	{
	}
}
