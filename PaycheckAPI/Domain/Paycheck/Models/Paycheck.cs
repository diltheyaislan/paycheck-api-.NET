using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace PaycheckAPI.Domain.Paycheck.Models
{
    public class Paycheck
    {
				private List<PaycheckEntry> _Entries = new List<PaycheckEntry>();
				
				[JsonIgnore]
				public DateTime Period { get; set; }

				public string ReferencePeriod {
						get {	return Period.ToString("MM/yyyy"); }
				}

				public decimal GrossSalary { get; set; }

				public decimal NetSalary { 
					get { return GrossSalary - TotalDiscounts; } 
				} 

				public decimal TotalDiscounts { 
					get {
						return _Entries
							.Where(entry => entry.EntryType.Equals(Models.PaycheckEntryTypeEnum.Discount))
							.Aggregate(0m, (acc, entry) => acc + entry.Amount);
					} 
				}

				public List<PaycheckEntry> Entries { 
					get { return _Entries; } 
				}
    }
}