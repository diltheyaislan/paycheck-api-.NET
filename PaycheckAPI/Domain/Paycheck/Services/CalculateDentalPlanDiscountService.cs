namespace PaycheckAPI.Domain.Paycheck.Services
{
    public class CalculateDentalPlanDiscountService
    {
				public const decimal DiscountAmountDentalPlan = 5;

        public Models.PaycheckEntry execute()
				{
					Models.PaycheckEntry entry = new Models.PaycheckEntry();

					entry.Description = "Dental plan";
					entry.Amount = DiscountAmountDentalPlan;
					entry.EntryType = Models.PaycheckEntryTypeEnum.Discount;

					return entry;
				}
    }
}