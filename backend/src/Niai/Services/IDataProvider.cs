using System.Collections.Generic;
using Niai.Models;

namespace Niai.Services
{
	public interface IDataProvider
	{
		/// <summary>
		/// Kanji map keyed by character.
		/// </summary>
		SafeMap<Kanji> Kanjis { get; }

		/// <summary>
		/// Vocab map keyed by original reading.
		/// </summary>
		SafeMap<Vocab> Vocabs { get; }

		/// <summary>
		/// Shared readings keyed by kana reading.
		/// </summary>
		SafeMap<List<string>> Homonyms { get; }

		/// <summary>
		/// Shared meanings keyed by english normalized meaning.
		/// </summary>
		SafeMap<List<string>> Synonyms { get; }

		/// <summary>
		/// Metadata containing item counts.
		/// </summary>
		Metadata Metadata { get; }
	}
}
