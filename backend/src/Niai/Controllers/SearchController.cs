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
		public ActionResult<IEnumerable<KanjiDto>> Get(string q)
		{
			var kanjis = _dataProvider.Kanjis;

			var list = new List<KanjiDto>();

			foreach (var character in q)
			{
				if (!kanjis.TryGetValue(character.ToString(), out var kanji))
				{
					continue;
				}

				var similar = kanji.Similar.Select(x => kanjis[x]);
				var dto = _mapper.Map<KanjiDto>(kanji);
				dto.Similar = similar.Select(x => _mapper.Map<KanjiSummaryDto>(x)).ToList();

				list.Add(dto);
			}

			return Ok(list);
		}
	}
}
