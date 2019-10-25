namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhaDat", "Ten", c => c.String(nullable: false));
            AddColumn("dbo.TinRaoBDS", "TieuDe", c => c.String(nullable: false));
            DropColumn("dbo.NhaDat", "TieuDe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhaDat", "TieuDe", c => c.String(nullable: false));
            DropColumn("dbo.TinRaoBDS", "TieuDe");
            DropColumn("dbo.NhaDat", "Ten");
        }
    }
}
