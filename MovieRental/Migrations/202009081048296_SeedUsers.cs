namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'537da0f4-a58d-4a54-9fc8-8163ab7d9789', N'guest@MovieRental.com', 0, N'APk7naHtc8Ov3j+YRO2gWEoW5EnjJTUqOeGXbcYvHhdYJixuWeQJwWAbMhroroEsag==', N'cefd45af-7a07-4bf1-a163-e850e4ec9a60', NULL, 0, 0, NULL, 1, 0, N'guest@MovieRental.com')
            INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'72b68563-79bb-4431-9a60-149b4b075df6', N'admin@MovieRental.com', 0, N'AD1+Yu9OEo7/sFhvmf2LeRFezJGhW8uQx/8CWzJ0eKlAWT4PyjC2YGrfMVskh+P4Lg==', N'6b7e5e45-2719-4dcd-8c53-0d63098fd743', NULL, 0, 0, NULL, 1, 0, N'admin@MovieRental.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'485e214a-0e22-46ba-a97e-12e777bfde83', N'CanManageMovies')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'72b68563-79bb-4431-9a60-149b4b075df6', N'485e214a-0e22-46ba-a97e-12e777bfde83')

");

        }

        public override void Down()
        {
        }
    }
}
