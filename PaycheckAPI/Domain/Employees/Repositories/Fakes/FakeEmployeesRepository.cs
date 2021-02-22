using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PaycheckAPI.Entities;

namespace PaycheckAPI.Domain.Employees.Repositories.Fakes
{
	public class FakeEmployeesRepository : IEmployeesRepository
	{
		private List<Employee> _employees = new List<Employee>();

		public async Task<Employee> Create(Employee employee)
		{
			employee.Id = Guid.NewGuid();
			_employees.Add(employee);
			await Task.Delay(500);
			return employee;
		}

		public async Task<int> Delete(Employee employee)
		{
			int index = _employees.FindIndex(e => e.Id == employee.Id);
			_employees.RemoveAt(index);
			await Task.Delay(500);
			return 0;
		}

		public async Task<List<Employee>> GetAll()
		{
			await Task.Delay(500);
			return _employees;
		}

		public async Task<Employee> GetByID(Guid id)
		{
			int index = _employees.FindIndex(e => e.Id == id);
			await Task.Delay(500);
			return index >= 0 ? _employees[index] : null;
		}

		public async Task<Employee> Update(Employee employee)
		{
			int index = _employees.FindIndex(e => e.Id == employee.Id);
			if (index >= 0)
			{
				_employees[index] = employee;
			}
			await Task.Delay(500);
			return employee;
		}
	}
}