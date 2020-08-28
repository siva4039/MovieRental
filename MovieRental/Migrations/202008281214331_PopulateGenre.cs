namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id,Name) VALUES(1,'ACTION')");
            Sql("INSERT INTO Genres(Id,Name) VALUES(2,'THRILLER')");
            Sql("INSERT INTO Genres(Id,Name) VALUES(3,'DRAMA')");
            Sql("INSERT INTO Genres(Id,Name) VALUES(4,'SCIFI')");
            Sql("INSERT INTO Genres(Id,Name) VALUES(5,'HORROR')");
        }
        
        public override void Down()
        {
        }
    }
}
