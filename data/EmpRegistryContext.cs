using System.Data.Entity;
using data.models;

namespace data
{
    public class EmpRegistryContext : DbContext
    {
        public EmpRegistryContext(): base()
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}