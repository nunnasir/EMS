namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check_migrate_data : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Trainers", "CityId");
            AddForeignKey("dbo.Trainers", "CityId", "dbo.Cities", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "CityId", "dbo.Cities");
            DropIndex("dbo.Trainers", new[] { "CityId" });
        }
    }
}
