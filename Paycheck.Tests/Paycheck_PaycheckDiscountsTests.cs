using NUnit.Framework;
using PaycheckAPI.Domain.Paycheck.Services;

namespace Paycheck.Tests
{
    [TestFixture]
		public class PaycheckDiscountsTests
    {
        private CalculateINSSDiscountService _calculateINSSservice;
        private CalculateIRPFDiscountService _calculateIRPFservice;
        private CalculateFGTSDiscountService _calculateFGTSservice;
        private CalculateTransportationVoucherDiscountService _calculateTranspVoucherService;

				[SetUp]
        public void Setup()
        {
						_calculateINSSservice = new CalculateINSSDiscountService();
						_calculateIRPFservice = new CalculateIRPFDiscountService();
						_calculateFGTSservice = new CalculateFGTSDiscountService();
						_calculateTranspVoucherService = new CalculateTransportationVoucherDiscountService();
        }

        [TestCase(1045, 78.38)]
        [TestCase(2000, 180)]
        [TestCase(3000, 360)]
        [TestCase(6000, 840)]
        [TestCase(7000, 0)]
        public void TestCalculationINSSDiscount(decimal grossSalary, decimal expectedValue)
        {
						Assert.AreEqual(
							expectedValue,
							_calculateINSSservice.execute(grossSalary).Amount
						);
        }

        [TestCase(1900, 0)]
        [TestCase(2000, 142.8)]
        [TestCase(3000, 354.8)]
        [TestCase(4000, 636.13)]
        [TestCase(5000, 869.36)]
        public void TestCalculationIRPFDiscount(decimal grossSalary, decimal expectedValue)
        {
						Assert.AreEqual(
							expectedValue,
							_calculateIRPFservice.execute(grossSalary).Amount
						);
        }
       
			  [TestCase(3000, 240)]
        public void TestCalculationFGTSDiscount(decimal grossSalary, decimal expectedValue)
        {
						Assert.AreEqual(
							expectedValue,
							_calculateFGTSservice.execute(grossSalary).Amount
						);
        }
       
			  [TestCase(3000, 180)]
			  [TestCase(1200, 0)]
        public void TestCalculationTransportationVoucherDiscount(decimal grossSalary, decimal expectedValue)
        {
						Assert.AreEqual(
							expectedValue,
							_calculateTranspVoucherService.execute(grossSalary).Amount
						);
        }
    }
}