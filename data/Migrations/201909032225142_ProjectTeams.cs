namespace data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectTeams : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectMembers",
                c => new
                    {
                        ParticipantId = c.Guid(nullable: false),
                        ProjectWorkingTimePart = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProjectTeamId = c.Guid(),
                        ProjectParticipant_Id = c.Guid(),
                        ProjectTeam_ProjectTeamId = c.Guid(),
                    })
                .PrimaryKey(t => t.ParticipantId)
                .ForeignKey("dbo.Employees", t => t.ProjectParticipant_Id)
                .ForeignKey("dbo.ProjectTeams", t => t.ProjectTeam_ProjectTeamId)
                .Index(t => t.ProjectParticipant_Id)
                .Index(t => t.ProjectTeam_ProjectTeamId);
            
            CreateTable(
                "dbo.ProjectRoles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false, identity: true),
                        RoleTitle = c.String(nullable: false),
                        RoleDescription = c.String(),
                        ProjectMember_ParticipantId = c.Guid(),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.ProjectMembers", t => t.ProjectMember_ParticipantId)
                .Index(t => t.ProjectMember_ParticipantId);
            
            CreateTable(
                "dbo.ProjectTeams",
                c => new
                    {
                        ProjectTeamId = c.Guid(nullable: false, identity: true),
                        ProjectTitle = c.String(nullable: false),
                        ProjectDescription = c.String(),
                        ProjectMembers_ParticipantId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectTeamId)
                .ForeignKey("dbo.ProjectMembers", t => t.ProjectMembers_ParticipantId, cascadeDelete: true)
                .Index(t => t.ProjectMembers_ParticipantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectMembers", "ProjectTeam_ProjectTeamId", "dbo.ProjectTeams");
            DropForeignKey("dbo.ProjectTeams", "ProjectMembers_ParticipantId", "dbo.ProjectMembers");
            DropForeignKey("dbo.ProjectRoles", "ProjectMember_ParticipantId", "dbo.ProjectMembers");
            DropForeignKey("dbo.ProjectMembers", "ProjectParticipant_Id", "dbo.Employees");
            DropIndex("dbo.ProjectTeams", new[] { "ProjectMembers_ParticipantId" });
            DropIndex("dbo.ProjectRoles", new[] { "ProjectMember_ParticipantId" });
            DropIndex("dbo.ProjectMembers", new[] { "ProjectTeam_ProjectTeamId" });
            DropIndex("dbo.ProjectMembers", new[] { "ProjectParticipant_Id" });
            DropTable("dbo.ProjectTeams");
            DropTable("dbo.ProjectRoles");
            DropTable("dbo.ProjectMembers");
        }
    }
}
