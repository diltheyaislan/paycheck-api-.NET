using Microsoft.EntityFrameworkCore;
using PaycheckAPI.Models;

namespace PaycheckAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) 
        { }

				public DbSet<Employee> Employees { get; set; }
    }
}