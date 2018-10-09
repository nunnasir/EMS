namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Name", c => c.String(nullable: false));
        }
    }
}
