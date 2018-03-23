namespace TabletCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedNUllableFromForeignExField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "ForeignExchangeBound", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "ForeignExchangeBound", c => c.Boolean());
        }
    }
}
