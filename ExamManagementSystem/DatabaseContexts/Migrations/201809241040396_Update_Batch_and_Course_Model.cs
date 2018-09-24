namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Batch_and_Course_Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Batches", "OrganizationId", c => c.Int(nullable: false));
            AddColumn("dbo.Batches", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Courses", "Duration", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Duration", c => c.String());
            DropColumn("dbo.Batches", "IsDeleted");
            DropColumn("dbo.Batches", "OrganizationId");
        }
    }
}
