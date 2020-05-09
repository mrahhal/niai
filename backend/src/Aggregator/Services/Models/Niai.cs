using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Aggregator.Services.Models
{
	[DebuggerDisplay("{ToString(),nq}")]
	public class NiaiSimilarRadicalsEntry
	{
		public string Radical { get; set; }

		public List<(string Radical, double Score)> Similar { get; set; }

		public override string ToString()
		{
			var str = string.Join(", ", Similar.Select(x => $"{x.Radical}: {x.Score}"));
			return $"{Radical}: {str}";
		}
	}
}
