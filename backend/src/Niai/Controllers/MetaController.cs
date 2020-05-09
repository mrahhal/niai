using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Niai.Models.Dtos;
using Niai.Services;

namespace Niai.Controllers
{
	public class MetaController : NiaiControllerBase
	{
		private static readonly string Version = (Assembly
			.GetExecutingAssembly()
			.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false) as AssemblyInformationalVersionAttribute[])[0]
			.InformationalVersion;

		private readonly IMapper _mapper;
		private readonly IDataProvider _dataProvider;

		public MetaController(
			IMapper mapper,
			IDataProvider dataProvider)
		{
			_mapper = mapper;
			_dataProvider = dataProvider;
		}

		/// <summary>
		/// Returns metadata about the app.
		/// </summary>
		[HttpGet]
		public ActionResult<MetadataDto> Get()
		{
			var dto = _mapper.Map<MetadataDto>(_dataProvider.Metadata);

			dto.Version = Version;

			return Ok(dto);
		}
	}
}
