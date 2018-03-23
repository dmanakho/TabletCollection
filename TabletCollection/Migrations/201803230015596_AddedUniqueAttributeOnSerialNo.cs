namespace TabletCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUniqueAttributeOnSerialNo : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tablets", "SerialNo", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tablets", new[] { "SerialNo" });
        }
    }
}
