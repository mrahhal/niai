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
			if (!kanjis.TryGetValue(q, out var kanji))
			{
				return Ok(new List<KanjiDto>());
			}

			var similar = kanji.Similar.Select(x => kanjis[x]);
			var dto = _mapper.Map<KanjiDto>(kanji);
			dto.Similar = similar.Select(x => _mapper.Map<KanjiSummaryDto>(x)).ToList();

			return Ok(new List<KanjiDto> { dto });
		}
	}
}
