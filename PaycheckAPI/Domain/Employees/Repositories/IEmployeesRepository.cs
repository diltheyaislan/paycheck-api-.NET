using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PaycheckAPI.Entities;

namespace PaycheckAPI.Domain.Employees.Repositories
{
    public interface IEmployeesRepository
    {
        Task<List<Employee>> GetAll();        
				Task<Employee> GetByID(Guid id);        
				Task<Employee> Create(Employee employee);        
				Task<Employee> Update(Employee employee);        
				Task<Employee> Delete(Employee employee);   
    }
}