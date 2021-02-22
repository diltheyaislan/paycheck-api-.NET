using System;

namespace PaycheckAPI.Domain.Paycheck.Services
{
    public class CalculateFGTSDiscountService
    {
				public const decimal DiscountPercent = 8;
				
        public Models.PaycheckEntry execute(decimal grossSalary)
				{
					Models.PaycheckEntry entry = new Models.PaycheckEntry();

					decimal amount = grossSalary * DiscountPercent / 100;

					entry.Description = "FGTS";
					entry.Amount = Decimal.Round(amount, 2);
					entry.EntryType = Models.PaycheckEntryTypeEnum.Discount;

					return entry;
				}
    }
}