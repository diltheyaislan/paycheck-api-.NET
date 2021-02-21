using System.Collections.Generic;
using PaycheckAPI.Entities;

namespace PaycheckAPI.Domain.Paycheck.Services
{
    public class BuildPaycheckEntriesDiscountService
    {
				public const decimal DiscountPercentFGTS = 8;
				
				private readonly CalculateINSSDiscountService _calculateINSSDiscountService;
				private readonly CalculateIRPFDiscountService _calculateIRPFDiscountService;
				private readonly CalculateHealthPlanDiscountService _calculateHealthPlanDiscountService;
				private readonly CalculateDentalPlanDiscountService _calculateDentalPlanDiscountService;
				private readonly CalculateTransportationVoucherDiscountService _calculateTransportationVoucherDiscountService;
				private readonly CalculateFGTSDiscountService _calculateFGTSDiscountService;

				public BuildPaycheckEntriesDiscountService(
						CalculateINSSDiscountService calculateINSSDiscountService,
						CalculateIRPFDiscountService calculateIRPFDiscountService,
						CalculateHealthPlanDiscountService calculateHealthPlanDiscountService,
						CalculateDentalPlanDiscountService calculateDentalPlanDiscountService,
						CalculateTransportationVoucherDiscountService calculateTransportationVoucherDiscountService,
						CalculateFGTSDiscountService calculateFGTSDiscountService
					) 
				{
					_calculateINSSDiscountService = calculateINSSDiscountService;
					_calculateIRPFDiscountService = calculateIRPFDiscountService;
					_calculateHealthPlanDiscountService = calculateHealthPlanDiscountService;
					_calculateDentalPlanDiscountService = calculateDentalPlanDiscountService;
					_calculateTransportationVoucherDiscountService = calculateTransportationVoucherDiscountService;
					_calculateFGTSDiscountService = calculateFGTSDiscountService;
				}
				
				public List<Models.PaycheckEntry> execute(Employee employee)
				{
					List<Models.PaycheckEntry> entries = new List<Models.PaycheckEntry>();

					Models.PaycheckEntry INSSEntry = _calculateINSSDiscountService.execute(employee.grossWage);
					entries.Add(INSSEntry); 
					
					Models.PaycheckEntry IRPFEntry = _calculateIRPFDiscountService.execute(employee.grossWage);
					entries.Add(IRPFEntry); 
					
					Models.PaycheckEntry FGTSEntry = _calculateFGTSDiscountService.execute(employee.grossWage);
					entries.Add(FGTSEntry); 

					if (employee.hasHealthPlan)
					{
						Models.PaycheckEntry healthPlanEntry = _calculateHealthPlanDiscountService.execute();
						entries.Add(healthPlanEntry);  
					}

					if (employee.hasDentalPlan)
					{
						Models.PaycheckEntry dentalPlanEntry = _calculateDentalPlanDiscountService.execute();
						entries.Add(dentalPlanEntry);  
					}
					
					if (employee.hasTransportationVouchersDiscount)
					{
						Models.PaycheckEntry dentalPlanEntry = _calculateTransportationVoucherDiscountService.execute(employee.grossWage);
						entries.Add(dentalPlanEntry);  
					}

					return entries;
				}

    }
}