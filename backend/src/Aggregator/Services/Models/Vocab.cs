using System.Collections.Generic;
using System.Diagnostics;

namespace Aggregator.Services
{
	[DebuggerDisplay("{Vocab,nq}")]
	public class VocabModel
	{
		public string Vocab { get; set; }
		public string Kana { get; set; }
		public List<string> Meanings { get; set; }
		public List<TagModel> Tags { get; set; }
	}

	public class VocabModelRaw : List<List<object>>
	{
	}
}
