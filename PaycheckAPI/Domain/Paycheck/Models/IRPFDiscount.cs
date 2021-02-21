namespace PaycheckAPI.Domain.Paycheck.Models
{
    public class IRPFDiscount
    {
        public decimal StartSalaryRange { get; set; }
				public decimal EndSalaryRange { get; set; }
				public decimal Aliquot { get; set; }
				public decimal LimitAmount { get; set; }

				public IRPFDiscount(
						decimal startSalaryRange,
						decimal endSalaryRange,
						decimal aliquot,
						decimal limitAmount
					)
				{
					StartSalaryRange = startSalaryRange;
					EndSalaryRange = endSalaryRange;
					Aliquot = aliquot;
					LimitAmount = limitAmount;
				} 
    }
}