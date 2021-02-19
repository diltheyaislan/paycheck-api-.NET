using System;

namespace PaycheckAPI.Domain.Employees.Dtos
{
    public class UpdateEmployeeDTO
    {
				public string name { get; set; }
				public string lastName { get; set; }
				public string document { get; set; }
				public decimal? grossWage { get; set; }
				public DateTime? admissionDate { get; set; }
				public bool? hasHealthPlan { get; set; }
				public bool? hasDentalPlan { get; set; }
				public bool? hasTransportationVouchersDiscount { get; set; }
    }
}