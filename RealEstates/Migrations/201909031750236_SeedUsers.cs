namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e296cf50-24bb-4d72-a201-6acd78241fa0', N'thaisangdang@gmail.com', 0, N'AP3d1nMD0m5i4uCo7CQ26naSbXpLpT5pzDA8KnhSVbRoxdqLHkle+NOOfAFcAb+0Gw==', N'c01f5a38-ebac-4666-b957-75488f6101d7', NULL, 0, 0, NULL, 1, 0, N'thaisangdang@gmail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3cce6ebd-a42b-4a69-843c-d930eba9bde9', N'Admin')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
