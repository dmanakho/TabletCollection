namespace TabletCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedExtraPurchaseAndNotesFieldtoTabletModelRestrictedCommentsNotesForCollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tablets", "IsExtraPurchase", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tablets", "Notes", c => c.String(maxLength: 500));
            AlterColumn("dbo.Collections", "ChargeNotes", c => c.String(maxLength: 500));
            AlterColumn("dbo.Collections", "Comments", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Collections", "Comments", c => c.String());
            AlterColumn("dbo.Collections", "ChargeNotes", c => c.String());
            DropColumn("dbo.Tablets", "Notes");
            DropColumn("dbo.Tablets", "IsExtraPurchase");
        }
    }
}
