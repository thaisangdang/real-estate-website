namespace RealEstates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whatChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NhanVienSales", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NhanVienSales", "Email", c => c.String(maxLength: 200));
        }
    }
}
