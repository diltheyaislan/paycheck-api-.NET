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

		public Task<Employee> GetByID(Guid id)
		{
			throw new NotImplementedException();
		}
		public Task<Employee> Create(Employee employee)
		{
			throw new NotImplementedException();
		}

		public Task<Employee> Delete(Employee employee)
		{
			throw new NotImplementedException();
		}


		public Task<Employee> Update(Employee employee)
		{
			throw new NotImplementedException();
		}
	}
}