namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSoDonViDuAn : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DonViSanPham", newName: "DonViDuAn");
            RenameColumn(table: "dbo.PhiHoaHong", name: "DonViSanPham_Id", newName: "DonViDuAn_Id");
            RenameIndex(table: "dbo.PhiHoaHong", name: "IX_DonViSanPham_Id", newName: "IX_DonViDuAn_Id");
            CreateTable(
                "dbo.LoaiDonViDuAn",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(maxLength: 100),
                        MoTa = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DuAn", "SoDonViDuAn", c => c.Int(nullable: false));
            DropTable("dbo.LoaiDonViSanPham");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LoaiDonViSanPham",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(maxLength: 100),
                        MoTa = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.DuAn", "SoDonViDuAn");
            DropTable("dbo.LoaiDonViDuAn");
            RenameIndex(table: "dbo.PhiHoaHong", name: "IX_DonViDuAn_Id", newName: "IX_DonViSanPham_Id");
            RenameColumn(table: "dbo.PhiHoaHong", name: "DonViDuAn_Id", newName: "DonViSanPham_Id");
            RenameTable(name: "dbo.DonViDuAn", newName: "DonViSanPham");
        }
    }
}
