using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaycheckAPI.Entities;
using PaycheckAPI.Domain.Employees.Services;
using PaycheckAPI.Domain.Employees.Dtos;

namespace PaycheckAPI.Domain.Employees.Controllers
{
    [ApiController]
    [Route("v1/employees")]
		public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Employee>>> Get(
					[FromServices] ListEmployeesService service)
        {
            return await service.execute();
        }
       
			  [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> GetByID(
					[FromServices] ShowEmployeeService service, 
					Guid id)
        {
						return await service.execute(id);
        }
			  
				[HttpPost]
        [Route("")]
        public async Task<ActionResult<Employee>> Create(
					[FromServices] CreateEmployeeService service, 
					[FromBody] Employee model)
        {
						if (ModelState.IsValid)
            {
								return await service.execute(model);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
			  
				[HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> Update(
					[FromServices] UpdateEmployeeService service, 
					[FromBody] UpdateEmployeeDTO model,
					Guid id)
        {
						if (ModelState.IsValid)
            {
								return await service.execute(id, model);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
			  
				[HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(
					[FromServices] DeleteEmployeeService service, 
					Guid id)
        {
						if (await service.execute(id) > 0)
            {
								return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}