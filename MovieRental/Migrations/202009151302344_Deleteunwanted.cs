namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deleteunwanted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewRentals", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.NewRentals", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.NewRentals", new[] { "Customer_Id" });
            DropIndex("dbo.NewRentals", new[] { "Movie_Id" });
            DropTable("dbo.NewRentals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NewRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.NewRentals", "Movie_Id");
            CreateIndex("dbo.NewRentals", "Customer_Id");
            AddForeignKey("dbo.NewRentals", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NewRentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
