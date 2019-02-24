using System.Collections.Generic;
using Niai.Models;

namespace Niai.Services
{
	public interface IDataProvider
	{
		SafeMap<Kanji> Kanjis { get; }

		Metadata Metadata { get; }
	}
}
