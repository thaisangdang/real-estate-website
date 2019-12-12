namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TinRaoBDS", "LoaiNhaDatId", c => c.Int(nullable: false));
            AddColumn("dbo.TinRaoBDS", "ThoiHanDangTin", c => c.Int(nullable: false));
            CreateIndex("dbo.TinRaoBDS", "LoaiNhaDatId");
            AddForeignKey("dbo.TinRaoBDS", "LoaiNhaDatId", "dbo.LoaiNhaDat", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TinRaoBDS", "LoaiNhaDatId", "dbo.LoaiNhaDat");
            DropIndex("dbo.TinRaoBDS", new[] { "LoaiNhaDatId" });
            DropColumn("dbo.TinRaoBDS", "ThoiHanDangTin");
            DropColumn("dbo.TinRaoBDS", "LoaiNhaDatId");
        }
    }
}
