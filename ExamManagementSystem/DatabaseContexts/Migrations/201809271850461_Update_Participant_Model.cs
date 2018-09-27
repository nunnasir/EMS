namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Participant_Model : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Participants", "CityId");
            AddForeignKey("dbo.Participants", "CityId", "dbo.Cities", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "CityId", "dbo.Cities");
            DropIndex("dbo.Participants", new[] { "CityId" });
        }
    }
}
