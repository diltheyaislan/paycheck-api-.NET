using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PaycheckAPI.Infrastructure.Errors.Exceptions;

namespace PaycheckAPI.Infrastructure.Errors.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
		public class ErrorsController : ControllerBase
		{
				[Route("error")]
				public ErrorResponse Error()
				{
						var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
						var exception = context.Error;
						var code = 500; 

						if (exception is AppException appException)
						{
								code = (int) appException.Status;
						}

						Response.StatusCode = code;

						return new ErrorResponse(exception);
				}
		}
}