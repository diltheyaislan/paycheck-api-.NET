namespace PaycheckAPI.Domain.Paycheck.Models
{
    public class INSSDiscount
    {
        public decimal StartSalaryRange { get; set; }
				public decimal EndSalaryRange{ get; set; }
				public decimal Aliquot{ get; set; }

				public INSSDiscount(
						decimal startSalaryRange,
						decimal endSalaryRange,
						decimal aliquot
					)
				{
					StartSalaryRange = startSalaryRange;
					EndSalaryRange = endSalaryRange;
					Aliquot = aliquot;
				} 
    }
}