using System.Collections.Generic;

namespace Niai.Models.Dtos
{
	public class VocabDto
	{
		public string Kanji { get; set; }

		public int? Frequency { get; set; }

		public List<VocabContextualMeaningDto> Meanings { get; set; }
	}

	public class VocabContextualMeaningDto
	{
		public string Kanji { get; set; }

		public string Kana { get; set; }

		public List<string> Meanings { get; set; }

		public List<Tag> Tags { get; set; }
	}
}
