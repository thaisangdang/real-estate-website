namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChange3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PhiHoaHong", name: "NhanVienSalesId", newName: "NguoiTaoId");
            RenameIndex(table: "dbo.PhiHoaHong", name: "IX_NhanVienSalesId", newName: "IX_NguoiTaoId");
            DropColumn("dbo.PhiHoaHong", "NguoiTao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhiHoaHong", "NguoiTao", c => c.String());
            RenameIndex(table: "dbo.PhiHoaHong", name: "IX_NguoiTaoId", newName: "IX_NhanVienSalesId");
            RenameColumn(table: "dbo.PhiHoaHong", name: "NguoiTaoId", newName: "NhanVienSalesId");
        }
    }
}
