using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaycheckAPI.Domain.Paycheck.Services;

namespace PaycheckAPI.Domain.Paycheck.Controllers
{
		[ApiController]
		[Route("v1")]
    public class PaycheckController : ControllerBase
    {
				[HttpGet]
        [Route("employees/{employeeId}/paycheck")]
        public async Task<ActionResult<Models.Paycheck>> Get(
						[FromServices] BuildPaycheckService service, 
						Guid employeeId
					)
        {
						return await service.execute(employeeId);
        }
    }
}