namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DuAn", "SoDonViSanPham", c => c.Int(nullable: false));
            DropColumn("dbo.DuAn", "SoDonViDuAn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DuAn", "SoDonViDuAn", c => c.Int(nullable: false));
            DropColumn("dbo.DuAn", "SoDonViSanPham");
        }
    }
}
