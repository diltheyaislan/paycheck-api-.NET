using System;
using System.ComponentModel.DataAnnotations;

namespace PaycheckAPI.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
				
				[Required(ErrorMessage = "This field is required")]
				public string name { get; set; }

				[Required(ErrorMessage = "This field is required")]
				public string lastName { get; set; }

				[Required(ErrorMessage = "This field is required")]
				public string document { get; set; }

				[Required(ErrorMessage = "This field is required")]
				public decimal grossWage { get; set; }

				[Required(ErrorMessage = "This field is required")]
				public DateTime admissionDate { get; set; }

				[Required(ErrorMessage = "This field is required")]
				public bool hasHealthPlan { get; set; }

				[Required(ErrorMessage = "This field is required")]
				public bool hasDentalPlan { get; set; }

				[Required(ErrorMessage = "This field is required")]
				public bool hasTransportationVouchersDiscount { get; set; }
    }
}