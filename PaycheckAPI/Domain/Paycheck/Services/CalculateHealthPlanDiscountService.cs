namespace PaycheckAPI.Domain.Paycheck.Services
{
    public class CalculateHealthPlanDiscountService
    {
				public const decimal DiscountAmountHealthPlan = 10;

        public Models.PaycheckEntry execute()
				{
					Models.PaycheckEntry entry = new Models.PaycheckEntry();

					entry.Description = "Health plan";
					entry.Amount = DiscountAmountHealthPlan;
					entry.EntryType = Models.PaycheckEntryTypeEnum.Discount;

					return entry;
				}
    }
}