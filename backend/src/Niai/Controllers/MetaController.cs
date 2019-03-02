using Microsoft.AspNetCore.Mvc;
using Niai.Models;
using Niai.Services;

namespace Niai.Controllers
{
	public class MetaController : NiaiControllerBase
	{
		private readonly IDataProvider _dataProvider;

		public MetaController(
			IDataProvider dataProvider)
		{
			_dataProvider = dataProvider;
		}

		[HttpGet]
		public ActionResult<Metadata> Get()
		{
			return Ok(_dataProvider.Metadata);
		}
	}
}
