using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PaycheckAPI.Domain.Employees.Repositories;
using PaycheckAPI.Infrastructure.EFCore.Data;
using PaycheckAPI.Infrastructure.EFCore.Repositories;
using PaycheckAPI.Domain.Employees.Services;
using PaycheckAPI.Domain.Paycheck.Services;

namespace PaycheckAPI.Infrastructure.IoC
{
    public static class ServiceIoC
    {
        public static void execute(IServiceCollection services, IConfiguration configuration) {
					services.AddDbContext<DataContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
          services.AddScoped<DataContext, DataContext>();

					services.AddScoped<IEmployeesRepository, EmployeesRepository>();

					services.AddScoped<ListEmployeesService, ListEmployeesService>();
					services.AddScoped<ShowEmployeeService, ShowEmployeeService>();
					services.AddScoped<CreateEmployeeService, CreateEmployeeService>();
					services.AddScoped<UpdateEmployeeService, UpdateEmployeeService>();
					services.AddScoped<DeleteEmployeeService, DeleteEmployeeService>();

					services.AddScoped<BuildPaycheckService, BuildPaycheckService>();
					services.AddScoped<BuildPaycheckEntriesRemunarationService, BuildPaycheckEntriesRemunarationService>();
					services.AddScoped<BuildPaycheckEntriesDiscountService, BuildPaycheckEntriesDiscountService>();
					services.AddScoped<CalculateINSSDiscountService, CalculateINSSDiscountService>();
					services.AddScoped<CalculateIRPFDiscountService, CalculateIRPFDiscountService>();
					services.AddScoped<CalculateHealthPlanDiscountService, CalculateHealthPlanDiscountService>();
					services.AddScoped<CalculateDentalPlanDiscountService, CalculateDentalPlanDiscountService>();
					services.AddScoped<CalculateTransportationVoucherDiscountService, CalculateTransportationVoucherDiscountService>();
					services.AddScoped<CalculateFGTSDiscountService, CalculateFGTSDiscountService>();
				}
    }
}