namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Deleted_On_Organization : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "IsDeleted");
        }
    }
}
