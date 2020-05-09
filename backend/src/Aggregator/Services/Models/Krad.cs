using System.Collections.Generic;
using System.Diagnostics;

namespace Aggregator.Services.Models
{
	[DebuggerDisplay("{ToString(),nq}")]
	public class KradFileEntry
	{
		public string Kanji { get; set; }

		public List<string> Radicals { get; set; }

		public override string ToString()
		{
			var radicalsString = string.Join(" ", Radicals);
			return $"{Kanji}: {radicalsString}";
		}
	}

	[DebuggerDisplay("{ToString(),nq}")]
	public class RadkFileEntry
	{
		public string Radical { get; set; }

		public List<string> Kanjis { get; set; }

		public override string ToString()
		{
			var kanjisString = string.Join(" ", Kanjis);
			return $"{Radical}: {kanjisString}";
		}
	}
}
