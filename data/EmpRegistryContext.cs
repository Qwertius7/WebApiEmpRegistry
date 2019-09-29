using System.Data.Entity;
using data.models;

namespace data
{
    public class EmpRegistryContext : DbContext
    {
        public EmpRegistryContext(): base()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTeam>()
                .HasRequired(team => team.ProjectMembers)
                .WithMany()
                .WillCascadeOnDelete(true);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProjectRole> ProjectRoles { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<ProjectTeam> ProjectTeams { get; set; }
    }
}