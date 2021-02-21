namespace PaycheckAPI.Domain.Paycheck.Services
{
    public class CalculateTransportationVoucherDiscountService
    {
				public const decimal DiscountPercent = 6;
				public const decimal MinimunAmountForDiscount = 1500;
				
        public Models.PaycheckEntry execute(decimal grossSalary)
				{
					Models.PaycheckEntry entry = new Models.PaycheckEntry();

					entry.Description = "Transportation voucher";
					entry.Amount = 0;
					entry.EntryType = Models.PaycheckEntryTypeEnum.Discount;

					if (grossSalary > MinimunAmountForDiscount)
					{
						entry.Amount = grossSalary * DiscountPercent / 100;
					}

					return entry;
				}
    }
}