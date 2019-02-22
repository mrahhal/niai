using System.Collections.Generic;
using Niai.Models;

namespace Niai.Services
{
	public interface IDataProvider
	{
		Dictionary<string, Kanji> Kanjis { get; }

		Metadata Metadata { get; }
	}
}
