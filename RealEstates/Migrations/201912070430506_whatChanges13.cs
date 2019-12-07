namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TinRaoBDS", "LoaiTinRao", c => c.Int(nullable: false));
            AddColumn("dbo.TinRaoBDS", "GiaTien", c => c.Decimal(nullable: false, storeType: "money"));
            DropColumn("dbo.TinRaoBDS", "IsRent");
            DropColumn("dbo.TinRaoBDS", "GiaBan");
            DropColumn("dbo.TinRaoBDS", "GiaThue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TinRaoBDS", "GiaThue", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.TinRaoBDS", "GiaBan", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("dbo.TinRaoBDS", "IsRent", c => c.Boolean(nullable: false));
            DropColumn("dbo.TinRaoBDS", "GiaTien");
            DropColumn("dbo.TinRaoBDS", "LoaiTinRao");
        }
    }
}
