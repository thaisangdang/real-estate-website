namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanVien", "PhongBanId", c => c.Int(nullable: false));
            CreateIndex("dbo.NhanVien", "PhongBanId");
            AddForeignKey("dbo.NhanVien", "PhongBanId", "dbo.PhongBan", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NhanVien", "PhongBanId", "dbo.PhongBan");
            DropIndex("dbo.NhanVien", new[] { "PhongBanId" });
            DropColumn("dbo.NhanVien", "PhongBanId");
        }
    }
}
