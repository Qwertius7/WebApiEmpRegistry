namespace data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SlightlyUpdatedDomainModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_Id" });
            RenameColumn(table: "dbo.Employees", name: "Department_Id", newName: "DepartmentId");
            AlterColumn("dbo.Employees", "DepartmentId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Employees", "DepartmentId");
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            AlterColumn("dbo.Employees", "DepartmentId", c => c.Guid());
            RenameColumn(table: "dbo.Employees", name: "DepartmentId", newName: "Department_Id");
            CreateIndex("dbo.Employees", "Department_Id");
            AddForeignKey("dbo.Employees", "Department_Id", "dbo.Departments", "Id");
        }
    }
}
