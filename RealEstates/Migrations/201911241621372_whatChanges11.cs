namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TinRaoBDS", "NhaDatId", "dbo.NhaDat");
            DropIndex("dbo.TinRaoBDS", new[] { "NhaDatId" });
            RenameColumn(table: "dbo.TinRaoBDS", name: "NhaDatId", newName: "NhaDat_Id");
            AddColumn("dbo.NhaDat", "AnhDaiDien", c => c.String());
            AddColumn("dbo.TinRaoBDS", "IsRent", c => c.Boolean(nullable: false));
            AddColumn("dbo.TinRaoBDS", "GiaBan", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.TinRaoBDS", "GiaThue", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.TinRaoBDS", "LoaiNhaDatId", c => c.Int(nullable: false));
            AddColumn("dbo.TinRaoBDS", "TinhThanhPhoId", c => c.Int(nullable: false));
            AddColumn("dbo.TinRaoBDS", "QuanHuyenId", c => c.Int(nullable: false));
            AddColumn("dbo.TinRaoBDS", "DiaChi", c => c.String());
            AddColumn("dbo.TinRaoBDS", "DienTich", c => c.Int(nullable: false));
            AddColumn("dbo.TinRaoBDS", "HuongNha", c => c.String());
            AddColumn("dbo.TinRaoBDS", "SoPhong", c => c.Int(nullable: false));
            AddColumn("dbo.TinRaoBDS", "ThongTinMoTa", c => c.String());
            AddColumn("dbo.TinRaoBDS", "Media", c => c.String());
            AddColumn("dbo.TinRaoBDS", "TuKhoa", c => c.String());
            AddColumn("dbo.TinRaoBDS", "BanDo", c => c.String());
            AddColumn("dbo.TinRaoBDS", "NgayTao", c => c.DateTime());
            AlterColumn("dbo.TinRaoBDS", "NhaDat_Id", c => c.Int());
            CreateIndex("dbo.TinRaoBDS", "LoaiNhaDatId");
            CreateIndex("dbo.TinRaoBDS", "TinhThanhPhoId");
            CreateIndex("dbo.TinRaoBDS", "QuanHuyenId");
            CreateIndex("dbo.TinRaoBDS", "NhaDat_Id");
            AddForeignKey("dbo.TinRaoBDS", "LoaiNhaDatId", "dbo.LoaiNhaDat", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TinRaoBDS", "QuanHuyenId", "dbo.QuanHuyen", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TinRaoBDS", "TinhThanhPhoId", "dbo.TinhThanhPho", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TinRaoBDS", "NhaDat_Id", "dbo.NhaDat", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TinRaoBDS", "NhaDat_Id", "dbo.NhaDat");
            DropForeignKey("dbo.TinRaoBDS", "TinhThanhPhoId", "dbo.TinhThanhPho");
            DropForeignKey("dbo.TinRaoBDS", "QuanHuyenId", "dbo.QuanHuyen");
            DropForeignKey("dbo.TinRaoBDS", "LoaiNhaDatId", "dbo.LoaiNhaDat");
            DropIndex("dbo.TinRaoBDS", new[] { "NhaDat_Id" });
            DropIndex("dbo.TinRaoBDS", new[] { "QuanHuyenId" });
            DropIndex("dbo.TinRaoBDS", new[] { "TinhThanhPhoId" });
            DropIndex("dbo.TinRaoBDS", new[] { "LoaiNhaDatId" });
            AlterColumn("dbo.TinRaoBDS", "NhaDat_Id", c => c.Int(nullable: false));
            DropColumn("dbo.TinRaoBDS", "NgayTao");
            DropColumn("dbo.TinRaoBDS", "BanDo");
            DropColumn("dbo.TinRaoBDS", "TuKhoa");
            DropColumn("dbo.TinRaoBDS", "Media");
            DropColumn("dbo.TinRaoBDS", "ThongTinMoTa");
            DropColumn("dbo.TinRaoBDS", "SoPhong");
            DropColumn("dbo.TinRaoBDS", "HuongNha");
            DropColumn("dbo.TinRaoBDS", "DienTich");
            DropColumn("dbo.TinRaoBDS", "DiaChi");
            DropColumn("dbo.TinRaoBDS", "QuanHuyenId");
            DropColumn("dbo.TinRaoBDS", "TinhThanhPhoId");
            DropColumn("dbo.TinRaoBDS", "LoaiNhaDatId");
            DropColumn("dbo.TinRaoBDS", "GiaThue");
            DropColumn("dbo.TinRaoBDS", "GiaBan");
            DropColumn("dbo.TinRaoBDS", "IsRent");
            DropColumn("dbo.NhaDat", "AnhDaiDien");
            RenameColumn(table: "dbo.TinRaoBDS", name: "NhaDat_Id", newName: "NhaDatId");
            CreateIndex("dbo.TinRaoBDS", "NhaDatId");
            AddForeignKey("dbo.TinRaoBDS", "NhaDatId", "dbo.NhaDat", "Id", cascadeDelete: true);
        }
    }
}
