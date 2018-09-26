namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImage_option_on_Trainer_Participant : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Participants", "Image", c => c.Binary());
            AlterColumn("dbo.Trainers", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "Image", c => c.Byte(nullable: false));
            AlterColumn("dbo.Participants", "Image", c => c.Byte(nullable: false));
        }
    }
}
