namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges16 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KhachHang", "AccountId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TinRaoBDS", "KhachHangId", "dbo.KhachHang");
            DropIndex("dbo.TinRaoBDS", new[] { "KhachHangId" });
            DropIndex("dbo.KhachHang", new[] { "AccountId" });
            AddColumn("dbo.TinRaoBDS", "AccountId", c => c.String(maxLength: 128));
            AddColumn("dbo.TinRaoBDS", "HoTen", c => c.String());
            AddColumn("dbo.TinRaoBDS", "SoDienThoai", c => c.String());
            AddColumn("dbo.TinRaoBDS", "Email", c => c.String());
            CreateIndex("dbo.TinRaoBDS", "AccountId");
            AddForeignKey("dbo.TinRaoBDS", "AccountId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.TinRaoBDS", "KhachHangId");
            DropTable("dbo.KhachHang");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoTen = c.String(),
                        SoDienThoai = c.String(),
                        Email = c.String(),
                        AccountId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TinRaoBDS", "KhachHangId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TinRaoBDS", "AccountId", "dbo.AspNetUsers");
            DropIndex("dbo.TinRaoBDS", new[] { "AccountId" });
            DropColumn("dbo.TinRaoBDS", "Email");
            DropColumn("dbo.TinRaoBDS", "SoDienThoai");
            DropColumn("dbo.TinRaoBDS", "HoTen");
            DropColumn("dbo.TinRaoBDS", "AccountId");
            CreateIndex("dbo.KhachHang", "AccountId");
            CreateIndex("dbo.TinRaoBDS", "KhachHangId");
            AddForeignKey("dbo.TinRaoBDS", "KhachHangId", "dbo.KhachHang", "Id", cascadeDelete: true);
            AddForeignKey("dbo.KhachHang", "AccountId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
