namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges19 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TinRaoBDS", "LoaiNhaDatId", "dbo.LoaiNhaDat");
            DropIndex("dbo.TinRaoBDS", new[] { "LoaiNhaDatId" });
            DropColumn("dbo.TinRaoBDS", "LoaiNhaDatId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TinRaoBDS", "LoaiNhaDatId", c => c.Int(nullable: false));
            CreateIndex("dbo.TinRaoBDS", "LoaiNhaDatId");
            AddForeignKey("dbo.TinRaoBDS", "LoaiNhaDatId", "dbo.LoaiNhaDat", "Id", cascadeDelete: true);
        }
    }
}
