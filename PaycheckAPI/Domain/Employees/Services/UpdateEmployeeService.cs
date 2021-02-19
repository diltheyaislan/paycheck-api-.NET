using System;
using System.Net;
using System.Threading.Tasks;
using PaycheckAPI.Entities;
using PaycheckAPI.Domain.Employees.Repositories;
using PaycheckAPI.Infrastructure.Errors.Exceptions;
using PaycheckAPI.Domain.Employees.Dtos;

namespace PaycheckAPI.Domain.Employees.Services
{
    public class UpdateEmployeeService
    {
				private readonly IEmployeesRepository _repository;

				public UpdateEmployeeService(IEmployeesRepository repository) 
				{
					_repository = repository;
				}

        public async Task<Employee> execute(Guid id, UpdateEmployeeDTO model)
				{
					var employee = await _repository.GetByID(id);
          
					if (employee == null)
          {
          	throw new AppException(HttpStatusCode.NotFound, "Employee not found");
          }

					if (model.name != null) 
					{
						employee.name = model.name;
					}

					if (model.lastName != null) 
					{
						employee.lastName = model.lastName;
					}

					if (model.document != null) 
					{
						employee.document = model.document;
					}

					if (model.grossWage.HasValue) 
					{
						employee.grossWage = (decimal) model.grossWage;
					}

					if (model.admissionDate.HasValue) 
					{
						employee.admissionDate = (DateTime) model.admissionDate;
					}

					if (model.hasHealthPlan.HasValue) 
					{
						employee.hasHealthPlan = (bool) model.hasHealthPlan;
					}

					if (model.hasDentalPlan.HasValue) 
					{
						employee.hasDentalPlan = (bool) model.hasDentalPlan;
					}

					if (model.hasTransportationVouchersDiscount.HasValue) 
					{
						employee.hasTransportationVouchersDiscount = (bool) model.hasTransportationVouchersDiscount;
					}
					
					return await _repository.Update(employee);
				}
    }
}