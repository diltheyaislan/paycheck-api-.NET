using System;
using System.Net;
using System.Threading.Tasks;
using PaycheckAPI.Entities;
using PaycheckAPI.Domain.Employees.Repositories;
using PaycheckAPI.Infrastructure.Errors.Exceptions;
using PaycheckAPI.Domain.Employees.Dtos;

namespace PaycheckAPI.Domain.Employees.Services
{
    public class DeleteEmployeeService
    {
				private readonly IEmployeesRepository _repository;

				public DeleteEmployeeService(IEmployeesRepository repository) 
				{
					_repository = repository;
				}

        public async Task<int> execute(Guid id)
				{
					var employee = await _repository.GetByID(id);
          
					if (employee == null)
          {
          	throw new AppException(HttpStatusCode.NotFound, "Employee not found");
          }

					return await _repository.Delete(employee);
				}
    }
}