namespace data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedKeyGeneration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropPrimaryKey("dbo.Departments");
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Departments", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Employees", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Departments", "Id");
            AddPrimaryKey("dbo.Employees", "Id");
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropPrimaryKey("dbo.Employees");
            DropPrimaryKey("dbo.Departments");
            AlterColumn("dbo.Employees", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Departments", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Employees", "Id");
            AddPrimaryKey("dbo.Departments", "Id");
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
