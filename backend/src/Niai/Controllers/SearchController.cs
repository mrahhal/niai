using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Niai.Models.Dtos;
using Niai.Services;

namespace Niai.Controllers
{
	public class SearchController : NiaiControllerBase
	{
		private readonly IDataProvider _dataProvider;
		private readonly IModelMapper _modelMapper;

		public SearchController(
			IDataProvider dataProvider,
			IModelMapper modelMapper)
		{
			_dataProvider = dataProvider;
			_modelMapper = modelMapper;
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
			var processedCharacters = new List<string>();

			var dtos = _modelMapper.Map(q.Select(character =>
			{
				var c = character.ToString();

				if (!kanjis.TryGetValue(c, out var kanji))
				{
					return null;
				}

				// Ignore if we already saw the character.
				if (processedCharacters.Any(x => x == c))
				{
					return null;
				}

				return kanji;
			}).Where(x => x != null))
			.ToList();

			return dtos;
		}

		private List<VocabDto> FindHomonyms(string q)
		{
			var vocabs = _dataProvider.Vocabs;
			var homonyms = _dataProvider.Homonyms;

			var homonym = homonyms[q];

			if (homonym == null)
			{
				return new List<VocabDto>();
			}

			return _modelMapper.Map(homonym.Select(x =>
			{
				var vocab = vocabs[x];
				return vocab;
			}).OrderByDescending(x => x.Frequency));
		}

		private List<VocabDto> FindSynonyms(string q)
		{
			q = q.ToLowerInvariant();

			var vocabs = _dataProvider.Vocabs;
			var synonyms = _dataProvider.Synonyms;

			var synonym = synonyms[q];

			if (synonym == null)
			{
				return new List<VocabDto>();
			}

			return _modelMapper.Map(synonym.Select(x =>
			{
				var vocab = vocabs[x];
				return vocab;
			}).OrderByDescending(x => x.Frequency));
		}
	}
}
