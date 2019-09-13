namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhanCongDuAn", "TrangThai", c => c.Boolean(nullable: false));
            AddColumn("dbo.PhanCongDuAn", "NguoTao", c => c.String());
            AddColumn("dbo.PhanCongDuAn", "NgayTao", c => c.DateTime(nullable: false));
            DropColumn("dbo.PhanCongDuAn", "NguoiChi");
            DropColumn("dbo.PhanCongDuAn", "NgayChi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhanCongDuAn", "NgayChi", c => c.DateTime(nullable: false));
            AddColumn("dbo.PhanCongDuAn", "NguoiChi", c => c.String());
            DropColumn("dbo.PhanCongDuAn", "NgayTao");
            DropColumn("dbo.PhanCongDuAn", "NguoTao");
            DropColumn("dbo.PhanCongDuAn", "TrangThai");
        }
    }
}
