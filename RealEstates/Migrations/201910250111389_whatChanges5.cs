namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhaDat", "IsRent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhaDat", "IsRent");
        }
    }
}
