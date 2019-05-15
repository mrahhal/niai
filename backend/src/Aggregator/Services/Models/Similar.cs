using System.Collections.Generic;

namespace Aggregator.Services
{
	public class SimilarModelRaw : Dictionary<string, List<string>>
	{
	}

	public class SimilarModelWithScoreRaw : Dictionary<string, List<SimilarModelWithScoreSimilarRaw>>
	{
	}

	public class SimilarModelWithScoreSimilarRaw
	{
		public string Kan { get; set; }

		public double Score { get; set; }
	}
}
