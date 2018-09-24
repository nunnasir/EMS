namespace DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Country_Update_Participants_Trainer_Model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "OrganizationId", c => c.Int(nullable: false));
            AddColumn("dbo.Participants", "Name", c => c.String());
            AddColumn("dbo.Participants", "RegNo", c => c.String());
            AddColumn("dbo.Participants", "ContactNo", c => c.String());
            AddColumn("dbo.Participants", "Email", c => c.String());
            AddColumn("dbo.Participants", "AddressLine1", c => c.String());
            AddColumn("dbo.Participants", "AddressLine2", c => c.String());
            AddColumn("dbo.Participants", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.Participants", "CityId", c => c.Int(nullable: false));
            AddColumn("dbo.Participants", "PostalCode", c => c.String());
            AddColumn("dbo.Participants", "Profession", c => c.String());
            AddColumn("dbo.Participants", "Academy", c => c.String());
            AddColumn("dbo.Participants", "Image", c => c.Byte(nullable: false));
            AddColumn("dbo.Trainers", "OrganizationId", c => c.Int(nullable: false));
            AddColumn("dbo.Trainers", "Name", c => c.String());
            AddColumn("dbo.Trainers", "ContactNo", c => c.String());
            AddColumn("dbo.Trainers", "Email", c => c.String());
            AddColumn("dbo.Trainers", "AddressLine1", c => c.String());
            AddColumn("dbo.Trainers", "AddressLine2", c => c.String());
            AddColumn("dbo.Trainers", "CountryId", c => c.Int(nullable: false));
            AddColumn("dbo.Trainers", "CityId", c => c.Int(nullable: false));
            AddColumn("dbo.Trainers", "PostalCode", c => c.String());
            AddColumn("dbo.Trainers", "Image", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "Image");
            DropColumn("dbo.Trainers", "PostalCode");
            DropColumn("dbo.Trainers", "CityId");
            DropColumn("dbo.Trainers", "CountryId");
            DropColumn("dbo.Trainers", "AddressLine2");
            DropColumn("dbo.Trainers", "AddressLine1");
            DropColumn("dbo.Trainers", "Email");
            DropColumn("dbo.Trainers", "ContactNo");
            DropColumn("dbo.Trainers", "Name");
            DropColumn("dbo.Trainers", "OrganizationId");
            DropColumn("dbo.Participants", "Image");
            DropColumn("dbo.Participants", "Academy");
            DropColumn("dbo.Participants", "Profession");
            DropColumn("dbo.Participants", "PostalCode");
            DropColumn("dbo.Participants", "CityId");
            DropColumn("dbo.Participants", "CountryId");
            DropColumn("dbo.Participants", "AddressLine2");
            DropColumn("dbo.Participants", "AddressLine1");
            DropColumn("dbo.Participants", "Email");
            DropColumn("dbo.Participants", "ContactNo");
            DropColumn("dbo.Participants", "RegNo");
            DropColumn("dbo.Participants", "Name");
            DropColumn("dbo.Participants", "OrganizationId");
        }
    }
}
