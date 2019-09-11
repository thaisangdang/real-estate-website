namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DuAn", "TinhThanhPho_Id", "dbo.TinhThanhPho");
            DropIndex("dbo.DuAn", new[] { "TinhThanhPho_Id" });
            AlterColumn("dbo.DuAn", "ChuDauTu", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.DuAn", "DonViThietKe", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.DuAn", "DonViThiCong", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.DuAn", "DienTich", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.DuAn", "HienTrang", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.DuAn", "KhoiCong", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.DuAn", "HoanThanh", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.DuAn", "ThongTinDuAn", c => c.String(nullable: false));
            AlterColumn("dbo.DuAn", "Media", c => c.String(nullable: false));
            AlterColumn("dbo.DuAn", "ViTri", c => c.String(nullable: false));
            AlterColumn("dbo.DuAn", "AnhDaiDien", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.DuAn", "TinhThanhPho_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.DuAn", "TinhThanhPho_Id");
            AddForeignKey("dbo.DuAn", "TinhThanhPho_Id", "dbo.TinhThanhPho", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DuAn", "TinhThanhPho_Id", "dbo.TinhThanhPho");
            DropIndex("dbo.DuAn", new[] { "TinhThanhPho_Id" });
            AlterColumn("dbo.DuAn", "TinhThanhPho_Id", c => c.Int());
            AlterColumn("dbo.DuAn", "AnhDaiDien", c => c.String(maxLength: 500));
            AlterColumn("dbo.DuAn", "ViTri", c => c.String());
            AlterColumn("dbo.DuAn", "Media", c => c.String());
            AlterColumn("dbo.DuAn", "ThongTinDuAn", c => c.String());
            AlterColumn("dbo.DuAn", "HoanThanh", c => c.String(maxLength: 50));
            AlterColumn("dbo.DuAn", "KhoiCong", c => c.String(maxLength: 50));
            AlterColumn("dbo.DuAn", "HienTrang", c => c.String(maxLength: 50));
            AlterColumn("dbo.DuAn", "DienTich", c => c.String(maxLength: 500));
            AlterColumn("dbo.DuAn", "DonViThiCong", c => c.String(maxLength: 500));
            AlterColumn("dbo.DuAn", "DonViThietKe", c => c.String(maxLength: 500));
            AlterColumn("dbo.DuAn", "ChuDauTu", c => c.String(maxLength: 500));
            CreateIndex("dbo.DuAn", "TinhThanhPho_Id");
            AddForeignKey("dbo.DuAn", "TinhThanhPho_Id", "dbo.TinhThanhPho", "Id");
        }
    }
}
