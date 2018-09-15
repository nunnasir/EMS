namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_Model_Updated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.Courses", new[] { "Organization_Id" });
            RenameColumn(table: "dbo.Courses", name: "Organization_Id", newName: "OrganizationId");
            AlterColumn("dbo.Courses", "OrganizationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "OrganizationId");
            AddForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Courses", new[] { "OrganizationId" });
            AlterColumn("dbo.Courses", "OrganizationId", c => c.Int());
            RenameColumn(table: "dbo.Courses", name: "OrganizationId", newName: "Organization_Id");
            CreateIndex("dbo.Courses", "Organization_Id");
            AddForeignKey("dbo.Courses", "Organization_Id", "dbo.Organizations", "Id");
        }
    }
}
