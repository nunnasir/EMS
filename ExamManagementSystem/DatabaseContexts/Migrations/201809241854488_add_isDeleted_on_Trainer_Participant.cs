namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_isDeleted_on_Trainer_Participant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Trainers", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "IsDeleted");
            DropColumn("dbo.Participants", "IsDeleted");
        }
    }
}
