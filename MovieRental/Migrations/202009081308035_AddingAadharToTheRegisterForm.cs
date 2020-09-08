namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAadharToTheRegisterForm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AadharNumber", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AadharNumber");
        }
    }
}
