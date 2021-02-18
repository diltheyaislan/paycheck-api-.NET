using System.Collections.Generic;
using System.Threading.Tasks;
using PaycheckAPI.Entities;
using PaycheckAPI.Domain.Employees.Repositories;

namespace PaycheckAPI.Domain.Employees.Services
{
    public class ListEmployeesService
    {
				private readonly IEmployeesRepository _repository;

				public ListEmployeesService(IEmployeesRepository repository) 
				{
					_repository = repository;
				}

        public async Task<List<Employee>> execute()
				{
					return await _repository.GetAll();
				}
    }
}