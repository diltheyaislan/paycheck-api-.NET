using System.Collections.Generic;
using PaycheckAPI.Entities;

namespace PaycheckAPI.Domain.Paycheck.Services
{
    public class BuildPaycheckEntriesRemunarationService
    {
        public List<Models.PaycheckEntry> execute(Employee employee)
				{
					List<Models.PaycheckEntry> entries = new List<Models.PaycheckEntry>();

					Models.PaycheckEntry entry = new Models.PaycheckEntry();
					entry.Description = "Salary";
					entry.Amount = employee.grossWage;
					entry.EntryType = Models.PaycheckEntryTypeEnum.Remuneration;

					entries.Add(entry); 

					return entries;
				}
    }
}