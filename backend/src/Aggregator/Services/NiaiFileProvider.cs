using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aggregator.Services.Models;
using Niai;

namespace Aggregator.Services
{
	public interface INiaiFileProvider
	{
		SafeMap<NiaiSimilarRadicalsEntry> SimilarRadicals { get; }
	}

	public class NiaiFileProvider : INiaiFileProvider, ISetupService
	{
		private readonly IDictionaryProvider _dictionaryProvider;

		public NiaiFileProvider(
			IDictionaryProvider dictionaryProvider)
		{
			_dictionaryProvider = dictionaryProvider;
		}

		public SafeMap<NiaiSimilarRadicalsEntry> SimilarRadicals { get; private set; }

		public async Task SetupAsync()
		{
			SimilarRadicals = new SafeMap<NiaiSimilarRadicalsEntry>();

			var fileInfo = await _dictionaryProvider.GetNiaiSimilarRadicalsAsync();

			using var fs = fileInfo.OpenRead();
			using var sr = new StreamReader(fs, Encoding.UTF8);

			NiaiSimilarRadicalsEntry GetEntry(string radical)
			{
				if (!SimilarRadicals.TryGetValue(radical, out var entry1))
				{
					entry1 = SimilarRadicals[radical] = new NiaiSimilarRadicalsEntry
					{
						Radical = radical,
						Similar = new System.Collections.Generic.List<(string Radical, double Score)>(),
					};
				}
				return entry1;
			}

			while (!sr.EndOfStream)
			{
				var line = await sr.ReadLineAsync();
				if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
				{
					continue;
				}

				// Format is: R1 R2 Score
				var r1 = line[0].ToString();
				var r2 = line[2].ToString();
				var score = double.Parse(line[4..]);

				var e1 = GetEntry(r1);
				var e2 = GetEntry(r2);

				if (e1.Similar.Any(x => x.Radical == r2))
				{
					Console.WriteLine($"Found duplicates in niai/similar-radicals.txt: {r1} {r2}");
					continue;
				}

				e1.Similar.Add((r2, score));
				e2.Similar.Add((r1, score));
			}
		}
	}
}
