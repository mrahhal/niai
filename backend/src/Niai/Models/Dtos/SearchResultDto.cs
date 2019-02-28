using System.Collections.Generic;

namespace Niai.Models.Dtos
{
	public class SearchResultDto
	{
		public List<KanjiDto> Kanjis { get; set; }

		public List<VocabDto> Homonyms { get; set; }

		public List<VocabDto> Synonyms { get; set; }
	}
}
