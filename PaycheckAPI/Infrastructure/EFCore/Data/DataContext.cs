using Microsoft.EntityFrameworkCore;
using PaycheckAPI.Entities;

namespace PaycheckAPI.Infrastructure.EFCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) 
        { }

				public DbSet<Employee> Employees { get; set; }
    }
}