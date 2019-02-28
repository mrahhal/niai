using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Niai.Models.Dtos;
using Niai.Services;

namespace Niai.Controllers
{
	public class SearchController : NiaiControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IDataProvider _dataProvider;

		public SearchController(
			IMapper mapper,
			IDataProvider dataProvider)
		{
			_mapper = mapper;
			_dataProvider = dataProvider;
		}

		[HttpGet]
		public ActionResult<SearchResultDto> Get(string q)
		{
			var result = new SearchResultDto();

			if (string.IsNullOrWhiteSpace(q))
			{
				return Ok(result);
			}

			result.Kanjis = FindSimilarKanjis(q);
			result.Homonyms = FindHomonyms(q);
			result.Synonyms = FindSynonyms(q);

			return Ok(result);
		}

		private List<KanjiDto> FindSimilarKanjis(string q)
		{
			var kanjis = _dataProvider.Kanjis;
			var list = new List<KanjiDto>();

			foreach (var character in q)
			{
				var c = character.ToString();

				if (!kanjis.TryGetValue(c, out var kanji))
				{
					continue;
				}

				// Ignore if we already saw the character.
				if (list.Any(x => x.Character == c))
				{
					continue;
				}

				var similar = kanji.Similar.Select(x => kanjis[x]).Where(x => x != null);
				var dto = _mapper.Map<KanjiDto>(kanji);
				dto.Similar = similar.Select(x => _mapper.Map<KanjiSummaryDto>(x)).ToList();

				list.Add(dto);
			}

			return list;
		}

		private List<VocabDto> FindHomonyms(string q)
		{
			var vocabs = _dataProvider.Vocabs;
			var homonyms = _dataProvider.Homonyms;

			var homonym = homonyms[q];

			if (homonym == null || homonym.Count <= 1)
			{
				return new List<VocabDto>();
			}

			return homonym.Select(x =>
			{
				var vocab = vocabs[x];
				return _mapper.Map<VocabDto>(vocab);
			}).ToList();
		}

		private List<VocabDto> FindSynonyms(string q)
		{
			var vocabs = _dataProvider.Vocabs;
			var synonyms = _dataProvider.Synonyms;

			var synonym = synonyms[q];

			if (synonym == null || synonym.Count <= 1)
			{
				return new List<VocabDto>();
			}

			return synonym.Select(x =>
			{
				var vocab = vocabs[x];
				return _mapper.Map<VocabDto>(vocab);
			}).ToList();
		}
	}
}
