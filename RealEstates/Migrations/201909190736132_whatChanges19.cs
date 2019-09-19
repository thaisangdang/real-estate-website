namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges19 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NhanVien", "TrangThai", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanVien", "TrangThai", c => c.Byte(nullable: false));
        }
    }
}
