using System;

namespace PaycheckAPI.Domain.Paycheck.Services
{
    public class CalculateINSSDiscountService
    {
				public static readonly Models.INSSDiscount INSSRangeValues1 = new Models.INSSDiscount(0m, 1045m, 7.5m);
				public static readonly Models.INSSDiscount INSSRangeValues2 = new Models.INSSDiscount(1045.01m, 2089.60m, 9m);
				public static readonly Models.INSSDiscount INSSRangeValues3 = new Models.INSSDiscount(2089.61m, 3134.40m, 12m);
				public static readonly Models.INSSDiscount INSSRangeValues4 = new Models.INSSDiscount(3134.41m, 6101.06m, 14m);

        public Models.PaycheckEntry execute(decimal grossSalary)
				{
					Models.PaycheckEntry entry = new Models.PaycheckEntry();

					entry.Description = "INSS";
					entry.Amount = 0m;
					entry.EntryType = Models.PaycheckEntryTypeEnum.Discount;

					decimal INSSAliquot = GetINSSAliquotBySalaryRange(grossSalary);

					if (INSSAliquot > 0)
					{
						decimal amount = grossSalary * INSSAliquot / 100;
						entry.Amount = Decimal.Round(amount, 2);
					}

					return entry;
				}

				private decimal GetINSSAliquotBySalaryRange(decimal grossSalary)
				{
					Models.INSSDiscount[] INSSRanges = new Models.INSSDiscount[] {
						INSSRangeValues1,	INSSRangeValues2,	INSSRangeValues3,	INSSRangeValues4
					};

					foreach(Models.INSSDiscount range in INSSRanges)
					{
						if(grossSalary >= range.StartSalaryRange && grossSalary <= range.EndSalaryRange)
						{
							return range.Aliquot;
						}
					}

					return 0;
				}
    }
}