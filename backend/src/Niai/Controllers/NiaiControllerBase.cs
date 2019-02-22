using Microsoft.AspNetCore.Mvc;

namespace Niai.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public abstract class NiaiControllerBase : ControllerBase
	{
	}
}
