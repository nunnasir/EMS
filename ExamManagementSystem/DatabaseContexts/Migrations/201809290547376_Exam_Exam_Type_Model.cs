namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exam_Exam_Type_Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        ExamTypeId = c.Int(nullable: false),
                        Code = c.String(),
                        Topic = c.String(),
                        FullMarks = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.ExamTypes", t => t.ExamTypeId, cascadeDelete: false)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: false)
                .Index(t => t.OrganizationId)
                .Index(t => t.CourseId)
                .Index(t => t.ExamTypeId);
            
            CreateTable(
                "dbo.ExamTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Exams", "ExamTypeId", "dbo.ExamTypes");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropIndex("dbo.Exams", new[] { "ExamTypeId" });
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropIndex("dbo.Exams", new[] { "OrganizationId" });
            DropTable("dbo.ExamTypes");
            DropTable("dbo.Exams");
        }
    }
}
