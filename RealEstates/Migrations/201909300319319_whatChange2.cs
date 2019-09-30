namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChange2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhiHoaHong", "NgayTao", c => c.DateTime());
            AlterColumn("dbo.PhanCongSanPham", "NgayTao", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhanCongSanPham", "NgayTao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PhiHoaHong", "NgayTao", c => c.DateTime(nullable: false));
        }
    }
}
