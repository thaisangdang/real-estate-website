namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NhaDat", "QuanHuyenId", "dbo.QuanHuyen");
            DropForeignKey("dbo.NhaDat", "TinhThanhPhoId", "dbo.TinhThanhPho");
            DropIndex("dbo.NhaDat", new[] { "TinhThanhPhoId" });
            DropIndex("dbo.NhaDat", new[] { "QuanHuyenId" });
            DropColumn("dbo.NhaDat", "TinhThanhPhoId");
            DropColumn("dbo.NhaDat", "QuanHuyenId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhaDat", "QuanHuyenId", c => c.Int(nullable: false));
            AddColumn("dbo.NhaDat", "TinhThanhPhoId", c => c.Int(nullable: false));
            CreateIndex("dbo.NhaDat", "QuanHuyenId");
            CreateIndex("dbo.NhaDat", "TinhThanhPhoId");
            AddForeignKey("dbo.NhaDat", "TinhThanhPhoId", "dbo.TinhThanhPho", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NhaDat", "QuanHuyenId", "dbo.QuanHuyen", "Id", cascadeDelete: true);
        }
    }
}
