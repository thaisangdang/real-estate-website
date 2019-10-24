namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaiViet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoaiBaiVietId = c.Int(nullable: false),
                        TieuDe = c.String(nullable: false),
                        NoiDung = c.String(),
                        NgayTao = c.DateTime(nullable: false),
                        NguoiTaoId = c.Int(nullable: false),
                        NgayBatDauDang = c.DateTime(nullable: false),
                        NgayKetThuc = c.DateTime(nullable: false),
                        LuotXem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoaiBaiViet", t => t.LoaiBaiVietId, cascadeDelete: true)
                .ForeignKey("dbo.NhanVien", t => t.NguoiTaoId, cascadeDelete: true)
                .Index(t => t.LoaiBaiVietId)
                .Index(t => t.NguoiTaoId);
            
            CreateTable(
                "dbo.LoaiBaiViet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoanhNghiepBDS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false),
                        DiaChi = c.String(),
                        SoDienThoai = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        GioiThieu = c.String(),
                        AnhDaiDien = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DuAn", "DoanhNghiepBDSId", c => c.Int(nullable: false));
            AddColumn("dbo.TinRaoBDS", "AnhDaiDien", c => c.String());
            CreateIndex("dbo.DuAn", "DoanhNghiepBDSId");
            AddForeignKey("dbo.DuAn", "DoanhNghiepBDSId", "dbo.DoanhNghiepBDS", "Id", cascadeDelete: true);
            DropColumn("dbo.TinRaoBDS", "LoaiTinRao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TinRaoBDS", "LoaiTinRao", c => c.Int(nullable: false));
            DropForeignKey("dbo.BaiViet", "NguoiTaoId", "dbo.NhanVien");
            DropForeignKey("dbo.DuAn", "DoanhNghiepBDSId", "dbo.DoanhNghiepBDS");
            DropForeignKey("dbo.BaiViet", "LoaiBaiVietId", "dbo.LoaiBaiViet");
            DropIndex("dbo.DuAn", new[] { "DoanhNghiepBDSId" });
            DropIndex("dbo.BaiViet", new[] { "NguoiTaoId" });
            DropIndex("dbo.BaiViet", new[] { "LoaiBaiVietId" });
            DropColumn("dbo.TinRaoBDS", "AnhDaiDien");
            DropColumn("dbo.DuAn", "DoanhNghiepBDSId");
            DropTable("dbo.DoanhNghiepBDS");
            DropTable("dbo.LoaiBaiViet");
            DropTable("dbo.BaiViet");
        }
    }
}
