namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges30 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhanCongSanPham", "SanPham", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhanCongSanPham", "SanPham", c => c.String());
        }
    }
}
