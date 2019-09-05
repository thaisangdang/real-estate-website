namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTenLoaiDuAn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoaiDuAn", "TenLoai", c => c.String(maxLength: 50));
            DropColumn("dbo.LoaiDuAn", "Loai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoaiDuAn", "Loai", c => c.String(maxLength: 50));
            DropColumn("dbo.LoaiDuAn", "TenLoai");
        }
    }
}
