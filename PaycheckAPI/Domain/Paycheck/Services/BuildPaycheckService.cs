using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using PaycheckAPI.Entities;
using PaycheckAPI.Domain.Employees.Services;

namespace PaycheckAPI.Domain.Paycheck.Services
{
    public class BuildPaycheckService
    {
				private readonly ShowEmployeeService _showEmployeeService;
				private readonly BuildPaycheckEntriesRemunarationService _buildPaycheckEntriesRemunarationService;
				private readonly BuildPaycheckEntriesDiscountService _buildPaycheckEntriesDiscountService;

				public BuildPaycheckService(
					ShowEmployeeService showEmployeeService,
					BuildPaycheckEntriesRemunarationService buildPaycheckEntriesRemunarationService,
					BuildPaycheckEntriesDiscountService buildPaycheckEntriesDiscountService
				) 
				{
					_showEmployeeService = showEmployeeService;
					_buildPaycheckEntriesRemunarationService = buildPaycheckEntriesRemunarationService;
					_buildPaycheckEntriesDiscountService = buildPaycheckEntriesDiscountService;
				}

        public async Task<Models.Paycheck> execute(Guid employeeId)
				{
					Employee employee = await _showEmployeeService.execute(employeeId);
					
					Models.Paycheck paycheck = new Models.Paycheck();

					paycheck.Period = System.DateTime.Now.AddMonths(-1);
					paycheck.GrossSalary = employee.grossWage;

					List<Models.PaycheckEntry> remunerations = _buildPaycheckEntriesRemunarationService.execute(employee);
					foreach(Models.PaycheckEntry entry in remunerations)
					{
						if (entry.Amount > 0)
						{
							paycheck.Entries.Add(entry);
						}
					}
				
					List<Models.PaycheckEntry> discounts = _buildPaycheckEntriesDiscountService.execute(employee);
					foreach(Models.PaycheckEntry entry in discounts)
					{
						if (entry.Amount > 0)
						{
							paycheck.Entries.Add(entry);
						}
					}

					return paycheck;
				}
    }
}