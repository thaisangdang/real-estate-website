namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DuAn", "TrangThai", c => c.Byte(nullable: false));
            AddColumn("dbo.NhanVien", "TrangThai", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanVien", "TrangThai");
            DropColumn("dbo.DuAn", "TrangThai");
        }
    }
}
