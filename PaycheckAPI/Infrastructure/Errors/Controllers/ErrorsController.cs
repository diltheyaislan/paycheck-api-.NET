using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PaycheckAPI.Infrastructure.Errors.Exceptions;

namespace PaycheckAPI.Infrastructure.Errors.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
		[ApiController]
		public class ErrorsController : ControllerBase
		{
				[Route("/error")]
    		public IActionResult Error() => Problem();
		}
}