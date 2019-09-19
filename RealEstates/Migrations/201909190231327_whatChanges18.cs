namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges18 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DuAn", "TrangThai", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DuAn", "TrangThai", c => c.Byte(nullable: false));
        }
    }
}
