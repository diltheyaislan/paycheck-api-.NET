using System.Text.Json.Serialization;

namespace PaycheckAPI.Domain.Paycheck.Models
{
		public enum PaycheckEntryTypeEnum
		{
				Remuneration,	
				Discount
		}

    public class PaycheckEntry
    {
				[JsonIgnore]
				public PaycheckEntryTypeEnum EntryType { get; set; }

				public string Type {
						get {	return EntryType.Equals(PaycheckEntryTypeEnum.Discount) ? "Discount" : "Remunaration"; }
				}

				public decimal Amount { get; set; }

				public string Description { get; set; }
    }
}