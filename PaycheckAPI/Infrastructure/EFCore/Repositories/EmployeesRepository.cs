using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PaycheckAPI.Infrastructure.EFCore.Data;
using PaycheckAPI.Domain.Employees.Repositories;
using PaycheckAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace PaycheckAPI.Infrastructure.EFCore.Repositories
{
	public class EmployeesRepository : IEmployeesRepository
	{
		private readonly DataContext DataContext;

		public EmployeesRepository(DataContext context) {
			DataContext = context;
		}
		
		async Task<List<Employee>> IEmployeesRepository.GetAll()
		{
			return await DataContext.Employees.ToListAsync();
		}

		async Task<Employee> IEmployeesRepository.GetByID(Guid id)
		{
			return await DataContext.Employees.FindAsync(id);
		}

		async Task<Employee> IEmployeesRepository.Create(Employee employee)
		{
			employee.Id = Guid.NewGuid();
			DataContext.Employees.Add(employee);
      await DataContext.SaveChangesAsync();
			return employee;
		}

		async Task<Employee> IEmployeesRepository.Update(Employee employee)
		{
    	DataContext.Employees.Update(employee);
      await DataContext.SaveChangesAsync();
			return employee;
		}

		async Task<int> IEmployeesRepository.Delete(Employee employee)
		{
			DataContext.Employees.Remove(employee);
      return await DataContext.SaveChangesAsync();
		}
	}
}