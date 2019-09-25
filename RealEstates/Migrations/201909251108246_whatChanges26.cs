namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges26 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhanCongSanPham", "TrangThai", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhanCongSanPham", "TrangThai", c => c.Boolean(nullable: false));
        }
    }
}
