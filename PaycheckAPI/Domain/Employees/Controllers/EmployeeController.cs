using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaycheckAPI.Entities;
using PaycheckAPI.Domain.Employees.Services;

namespace PaycheckAPI.Domain.Employees.Controllers
{
    [ApiController]
    [Route("v1/employees")]
		public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Employee>>> Get([FromServices] ListEmployeesService service)
        {
            var employees = await service.execute();
            return employees;
        }
    }
}