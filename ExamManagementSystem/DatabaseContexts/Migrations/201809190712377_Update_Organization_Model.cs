namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Organization_Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "Code", c => c.String());
            AddColumn("dbo.Organizations", "Address", c => c.String());
            AddColumn("dbo.Organizations", "ContactNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "ContactNo");
            DropColumn("dbo.Organizations", "Address");
            DropColumn("dbo.Organizations", "Code");
        }
    }
}
