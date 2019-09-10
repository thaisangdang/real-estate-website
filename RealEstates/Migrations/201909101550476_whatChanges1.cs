namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoaiDuAn", "TenLoai", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LoaiDuAn", "TenLoai", c => c.String(maxLength: 50));
        }
    }
}
