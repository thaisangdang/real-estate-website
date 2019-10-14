namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhiHoaHong", "NguoiTao", c => c.String());
            AddColumn("dbo.PhiHoaHong", "NgayTao", c => c.DateTime(nullable: false));
            DropColumn("dbo.PhiHoaHong", "NguoiChi");
            DropColumn("dbo.PhiHoaHong", "NgayChi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhiHoaHong", "NgayChi", c => c.DateTime(nullable: false));
            AddColumn("dbo.PhiHoaHong", "NguoiChi", c => c.String());
            DropColumn("dbo.PhiHoaHong", "NgayTao");
            DropColumn("dbo.PhiHoaHong", "NguoiTao");
        }
    }
}
