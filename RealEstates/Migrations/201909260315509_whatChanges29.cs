namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges29 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhanCongSanPham", "GiaBanSanPham", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.PhanCongSanPham", "GiaSanPham");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhanCongSanPham", "GiaSanPham", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.PhanCongSanPham", "GiaBanSanPham");
        }
    }
}
