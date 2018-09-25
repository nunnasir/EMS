namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Batch_Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Batches", "Name", c => c.String());
            DropColumn("dbo.Batches", "BatchNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Batches", "BatchNo", c => c.Int(nullable: false));
            DropColumn("dbo.Batches", "Name");
        }
    }
}
