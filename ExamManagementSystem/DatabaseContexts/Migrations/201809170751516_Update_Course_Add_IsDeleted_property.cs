namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Course_Add_IsDeleted_property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "IsDeleted");
        }
    }
}
