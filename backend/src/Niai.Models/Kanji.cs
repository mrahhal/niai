using System.Collections.Generic;

namespace Niai.Models
{
	public class Kanji
	{
		public string Character { get; set; }

		public List<string> Meanings { get; set; }

		public string Onyomi { get; set; }

		public string Kunyomi { get; set; }

		public int? WaniKaniLevel { get; set; }

		public List<Tag> Tags { get; set; }

		public int? Frequency { get; set; }

		public List<string> Similar { get; set; }
	}
}
