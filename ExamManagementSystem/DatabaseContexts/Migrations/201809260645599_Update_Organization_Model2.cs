namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Organization_Model2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Participants", "OrganizationId");
            CreateIndex("dbo.Trainers", "OrganizationId");
            AddForeignKey("dbo.Participants", "OrganizationId", "dbo.Organizations", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Trainers", "OrganizationId", "dbo.Organizations", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Participants", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Trainers", new[] { "OrganizationId" });
            DropIndex("dbo.Participants", new[] { "OrganizationId" });
        }
    }
}
