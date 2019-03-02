using System.Collections.Generic;
using Niai.Models;
using Niai.Models.Dtos;

namespace Niai.Services
{
	public interface IModelMapper
	{
		List<KanjiDto> Map(IEnumerable<Kanji> kanjis);

		List<VocabDto> Map(IEnumerable<Vocab> vocabs);
	}
}
