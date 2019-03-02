using System.Collections.Generic;

namespace Niai.Models
{
	public class Vocab
	{
		public string Kanji { get; set; }

		public int? Frequency { get; set; }

		public List<VocabContextualMeaning> Meanings { get; set; }
	}

	public class VocabContextualMeaning
	{
		public string Kana { get; set; }

		public List<string> Meanings { get; set; }

		public List<Tag> Tags { get; set; }
	}
}
