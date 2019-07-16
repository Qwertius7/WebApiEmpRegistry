using System.Data.Entity.Migrations;

namespace data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<data.EmpRegistryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}