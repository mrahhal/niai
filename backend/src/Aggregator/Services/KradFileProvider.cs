using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aggregator.Services.Models;
using Niai;

namespace Aggregator.Services
{
	public interface IKradFileProvider
	{
		SafeMap<KradFileEntry> Model { get; }

		SafeMap<RadkFileEntry> InverseModel { get; }

		int RadicalCount { get; }

		int KanjiCount { get; }
	}

	public class KradFileProvider : IKradFileProvider, ISetupService
	{
		private static readonly string[] RadicalsToSkip = new string[]
		{
			"｜", "一",
		};

		private readonly IDictionaryProvider _dictionaryProvider;

		public KradFileProvider(
			IDictionaryProvider dictionaryProvider)
		{
			_dictionaryProvider = dictionaryProvider;
		}

		public SafeMap<KradFileEntry> Model { get; private set; }

		public SafeMap<RadkFileEntry> InverseModel { get; private set; }

		public int RadicalCount => InverseModel.Count;

		public int KanjiCount => Model.Count;

		public async Task SetupAsync()
		{
			var file1 = await _dictionaryProvider.GetKradFileAsync();

			// Currently not working correctly with the encoding.
			//var file2 = await _dictionaryProvider.GetKradFile2Async();

			var encoding = CodePagesEncodingProvider.Instance.GetEncoding(20932 /* EUC-JP */);

			Model = new SafeMap<KradFileEntry>();

			async Task ProcessFileAsync(FileInfo fileInfo)
			{
				using var fs = fileInfo.OpenRead();
				using var sr = new StreamReader(fs, encoding);

				while (!sr.EndOfStream)
				{
					var line = await sr.ReadLineAsync();
					if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
					{
						continue;
					}

					//            0    4
					// Format is: 亜 : ｜ 一 口
					var kanji = line[0].ToString();
					var radicalsString = line[4..];
					var radicals = radicalsString.Split(' ')
						.Select(x => x.Trim())
						.Where(x => !string.IsNullOrEmpty(x) && !RadicalsToSkip.Contains(x))
						.ToList();

					Model[kanji] = new KradFileEntry
					{
						Kanji = kanji,
						Radicals = radicals,
					};
				}
			}

			await ProcessFileAsync(file1);

			await ComputeInverseModelAsync();
		}

		private Task ComputeInverseModelAsync()
		{
			var model = Model;

			InverseModel = new SafeMap<RadkFileEntry>();
			var allRadicals = model.Values.SelectMany(x => x.Radicals).Distinct().ToArray();

			foreach (var radical in allRadicals)
			{
				var kanjis = model.Values
					.Where(x => x.Radicals.Contains(radical))
					.Select(x => x.Kanji)
					.ToList();

				InverseModel[radical] = new RadkFileEntry
				{
					Radical = radical,
					Kanjis = kanjis,
				};
			}

			return Task.CompletedTask;
		}
	}
}
