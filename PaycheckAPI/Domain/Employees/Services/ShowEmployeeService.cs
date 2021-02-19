using System;
using System.Threading.Tasks;
using PaycheckAPI.Entities;
using PaycheckAPI.Domain.Employees.Repositories;
using PaycheckAPI.Infrastructure.Errors.Exceptions;
using System.Net;

namespace PaycheckAPI.Domain.Employees.Services
{
    public class ShowEmployeeService
    {
				private readonly IEmployeesRepository _repository;

				public ShowEmployeeService(IEmployeesRepository repository) 
				{
					_repository = repository;
				}

        public async Task<Employee> execute(Guid id)
				{
					var employee = await _repository.GetByID(id);
					if (employee != null) {
						return employee;
					} else {
						throw new AppException(HttpStatusCode.NotFound, "Employee not found");
					}
				}
    }
}