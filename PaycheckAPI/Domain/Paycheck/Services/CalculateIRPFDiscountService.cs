using System;

namespace PaycheckAPI.Domain.Paycheck.Services
{
    public class CalculateIRPFDiscountService
    {
				public static readonly Models.IRPFDiscount IRPFRangeValues1 = new Models.IRPFDiscount(1903.99m, 2826.65m, 7.5m, 142.80m);
				public static readonly Models.IRPFDiscount IRPFRangeValues2 = new Models.IRPFDiscount(2826.66m, 3751.05m, 15m, 354.80m);
				public static readonly Models.IRPFDiscount IRPFRangeValues3 = new Models.IRPFDiscount(3751.06m, 4664.68m, 22.5m, 636.13m);
				public static readonly Models.IRPFDiscount IRPFRangeValues4 = new Models.IRPFDiscount(4664.68m, System.Decimal.MaxValue, 27.5m, 869.36m);

        public Models.PaycheckEntry execute(decimal grossSalary)
				{
					Models.PaycheckEntry entry = new Models.PaycheckEntry();

					entry.Description = "IRPF";
					entry.Amount = 0m;
					entry.EntryType = Models.PaycheckEntryTypeEnum.Discount;

					Models.IRPFDiscount rangeValues = GetIRPFRangeValuesBySalaryRange(grossSalary);
					
					if (rangeValues != null)
					{
						decimal IRPFAmount = grossSalary * rangeValues.Aliquot / 100;
						entry.Amount = IRPFAmount <= rangeValues.LimitAmount ? Decimal.Round(IRPFAmount, 2) : rangeValues.LimitAmount;
					}

					return entry;
				}

				private Models.IRPFDiscount GetIRPFRangeValuesBySalaryRange(decimal grossSalary)
				{
					Models.IRPFDiscount[] IRPFRanges = new Models.IRPFDiscount[] {
						IRPFRangeValues1,	IRPFRangeValues2,	IRPFRangeValues3,	IRPFRangeValues4
					};

					foreach(Models.IRPFDiscount range in IRPFRanges)
					{
						if(grossSalary >= range.StartSalaryRange && grossSalary <= range.EndSalaryRange)
						{
							return range;
						}
					}

					return null;
				}
    }
}