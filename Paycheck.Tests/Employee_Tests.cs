using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PaycheckAPI.Entities;
using PaycheckAPI.Domain.Employees.Repositories.Fakes;
using PaycheckAPI.Domain.Employees.Services;

namespace Paycheck.Tests
{
    [TestFixture]
		public class Employee_Tests
    {
				private CreateEmployeeService _createService;
				private ShowEmployeeService _showService;

				[OneTimeSetUp]
        public async Task Setup()
        {
						FakeEmployeesRepository fakeEmployeesRepository = new FakeEmployeesRepository();

						_createService = new CreateEmployeeService(fakeEmployeesRepository);
						_showService = new ShowEmployeeService(fakeEmployeesRepository);
				}
	
				[Test]
				public async Task TestCreateEmployee()
				{
						Employee employeeData = new Employee(); 
						employeeData.name = "John";
						employeeData.lastName = "Doe";
						employeeData.document = "124578";
						employeeData.grossWage = 5000;
						employeeData.admissionDate = new System.DateTime(2019, 11, 06);
						employeeData.hasHealthPlan = true;
						employeeData.hasDentalPlan = true;
						employeeData.hasTransportationVouchersDiscount = true;

						Employee	createdEmployee = await _createService.execute(employeeData);

						Assert.NotNull(createdEmployee.Id);
				}

				[Test]
				public async Task TestGeyEmployeeByID()
				{
						Employee employeeData = new Employee(); 
						employeeData.name = "John";
						employeeData.lastName = "Doe";
						employeeData.document = "124578";
						employeeData.grossWage = 5000;
						employeeData.admissionDate = new System.DateTime(2019, 11, 06);
						employeeData.hasHealthPlan = true;
						employeeData.hasDentalPlan = true;
						employeeData.hasTransportationVouchersDiscount = true;

						Employee createdEmployee = await _createService.execute(employeeData);

						Employee foundEmployee = await _showService.execute(createdEmployee.Id);

						Assert.AreEqual(
							createdEmployee.Id,
							foundEmployee.Id
						);
				}
    }
}