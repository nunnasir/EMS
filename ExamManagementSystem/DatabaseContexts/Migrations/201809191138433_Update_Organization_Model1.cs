namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Organization_Model1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "About", c => c.String());
            AlterColumn("dbo.Organizations", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Organizations", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Organizations", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Organizations", "ContactNo", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "ContactNo", c => c.String());
            AlterColumn("dbo.Organizations", "Address", c => c.String());
            AlterColumn("dbo.Organizations", "Code", c => c.String());
            AlterColumn("dbo.Organizations", "Name", c => c.String());
            DropColumn("dbo.Organizations", "About");
        }
    }
}
