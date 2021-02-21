namespace PaycheckAPI.Domain.Paycheck.Services
{
    public class CalculateFGTSDiscountService
    {
				public const decimal DiscountPercent = 8;
				
        public Models.PaycheckEntry execute(decimal grossSalary)
				{
					Models.PaycheckEntry entry = new Models.PaycheckEntry();

					entry.Description = "FGTS";
					entry.Amount = grossSalary * DiscountPercent / 100;
					entry.EntryType = Models.PaycheckEntryTypeEnum.Discount;

					return entry;
				}
    }
}