namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Trainer_Course_Participant_Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.Trainers", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Participants", "CourseId");
            CreateIndex("dbo.Trainers", "CourseId");
            AddForeignKey("dbo.Participants", "CourseId", "dbo.Courses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Trainers", "CourseId", "dbo.Courses", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Participants", "CourseId", "dbo.Courses");
            DropIndex("dbo.Trainers", new[] { "CourseId" });
            DropIndex("dbo.Participants", new[] { "CourseId" });
            DropColumn("dbo.Trainers", "CourseId");
            DropColumn("dbo.Participants", "CourseId");
        }
    }
}
