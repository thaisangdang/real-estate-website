namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges22 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PhanCongDuAn", newName: "PhanCongSanPham");
            RenameColumn(table: "dbo.PhiHoaHong", name: "PhanCongDuAnId", newName: "PhanCongSanPhamId");
            RenameIndex(table: "dbo.PhiHoaHong", name: "IX_PhanCongDuAnId", newName: "IX_PhanCongSanPhamId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PhiHoaHong", name: "IX_PhanCongSanPhamId", newName: "IX_PhanCongDuAnId");
            RenameColumn(table: "dbo.PhiHoaHong", name: "PhanCongSanPhamId", newName: "PhanCongDuAnId");
            RenameTable(name: "dbo.PhanCongSanPham", newName: "PhanCongDuAn");
        }
    }
}
