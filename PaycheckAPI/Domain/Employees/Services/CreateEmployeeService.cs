using System.Threading.Tasks;
using PaycheckAPI.Entities;
using PaycheckAPI.Domain.Employees.Repositories;

namespace PaycheckAPI.Domain.Employees.Services
{
    public class CreateEmployeeService
    {
				private readonly IEmployeesRepository _repository;

				public CreateEmployeeService(IEmployeesRepository repository) 
				{
					_repository = repository;
				}

        public async Task<Employee> execute(Employee employee)
				{
					return await _repository.Create(employee);
				}
    }
}