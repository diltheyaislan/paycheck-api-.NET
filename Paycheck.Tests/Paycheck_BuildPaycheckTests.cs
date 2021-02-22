using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PaycheckAPI.Entities;
using PaycheckAPI.Domain.Employees.Repositories.Fakes;
using PaycheckAPI.Domain.Employees.Services;
using PaycheckAPI.Domain.Paycheck.Services;

namespace Paycheck.Tests
{
    [TestFixture]
		public class BuildPaycheckTests
    {
				private Employee _employee;
				private BuildPaycheckService _service;

				[OneTimeSetUp]
        public async Task Setup()
        {
						FakeEmployeesRepository fakeEmployeesRepository = new FakeEmployeesRepository();
						
						Employee employee = new Employee(); 
						employee.name = "John";
						employee.lastName = "Doe";
						employee.document = "124578";
						employee.grossWage = 5000;
						employee.admissionDate = new System.DateTime(2019, 11, 06);
						employee.hasHealthPlan = true;
						employee.hasDentalPlan = true;
						employee.hasTransportationVouchersDiscount = true;

						_employee = await fakeEmployeesRepository.Create(employee);
						
						ShowEmployeeService showEmployeeService = new ShowEmployeeService(fakeEmployeesRepository);
					
						CalculateINSSDiscountService calculateINSSDiscountService = new CalculateINSSDiscountService();
						CalculateIRPFDiscountService calculateIRPFDiscountService = new CalculateIRPFDiscountService();
						CalculateHealthPlanDiscountService calculateHealthPlanDiscountService = new CalculateHealthPlanDiscountService();
						CalculateDentalPlanDiscountService calculateDentalPlanDiscountService = new CalculateDentalPlanDiscountService();
						CalculateTransportationVoucherDiscountService calculateTransportationVoucherDiscountService = new CalculateTransportationVoucherDiscountService();
						CalculateFGTSDiscountService calculateFGTSDiscountService = new CalculateFGTSDiscountService();

						_service = new BuildPaycheckService(
							showEmployeeService,
							new BuildPaycheckEntriesRemunarationService(),
							new BuildPaycheckEntriesDiscountService(
								calculateINSSDiscountService,
								calculateIRPFDiscountService,
								calculateHealthPlanDiscountService,
								calculateDentalPlanDiscountService,
								calculateTransportationVoucherDiscountService,
								calculateFGTSDiscountService
							)
						);			
				}
	
				[Test]
				public async Task TestBuildPaycheck()
				{
						PaycheckAPI.Domain.Paycheck.Models.Paycheck paycheck = await _service.execute(_employee.Id);

						Assert.AreEqual(
							_employee.grossWage,
							paycheck.GrossSalary
						);
				}

				[TestCase(2715.64)]
				public async Task TestNetSalary(decimal netSalary)
				{
						PaycheckAPI.Domain.Paycheck.Models.Paycheck paycheck = await _service.execute(_employee.Id);

						Assert.AreEqual(
							netSalary,
							paycheck.NetSalary
						);
				}

				[TestCase(2284.36)]
				public async Task TestTotalDiscounts(decimal totalDiscounts)
				{
						PaycheckAPI.Domain.Paycheck.Models.Paycheck paycheck = await _service.execute(_employee.Id);

						Assert.AreEqual(
							totalDiscounts,
							paycheck.TotalDiscounts
						);
				}
    }
}