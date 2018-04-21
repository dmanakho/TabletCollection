namespace TabletCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LenovoBuyoutBoolean : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tablets", "IsVendorBuyout", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tablets", "IsVendorBuyout");
        }
    }
}
