using System.Collections.Generic;
using Niai;
using Niai.Models;

namespace Aggregator.Services
{
	public interface ISimilarDictionaryService
	{
		SafeMap<List<SimilarKanji>> Model { get; }
	}
}
