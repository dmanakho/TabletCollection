namespace TabletCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsPickedUpFiledAddedToTabletModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tablets", "IsPickedUp", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tablets", "IsPickedUp");
        }
    }
}
