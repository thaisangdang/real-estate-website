namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges17 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TinRaoBDS", "NgayBatDauDangTinRao");
            DropColumn("dbo.TinRaoBDS", "NgayKetThucDangTinRao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TinRaoBDS", "NgayKetThucDangTinRao", c => c.DateTime(nullable: false));
            AddColumn("dbo.TinRaoBDS", "NgayBatDauDangTinRao", c => c.DateTime(nullable: false));
        }
    }
}
