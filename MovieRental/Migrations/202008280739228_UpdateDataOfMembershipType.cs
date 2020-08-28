namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataOfMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name ='PayAsYouGo' where Id=1");
            Sql("UPDATE MembershipTypes SET Name ='Monthly' where Id=2");
            Sql("UPDATE MembershipTypes SET Name ='Quartarly' where Id=3");
            Sql("UPDATE MembershipTypes SET Name ='Yearly' where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
