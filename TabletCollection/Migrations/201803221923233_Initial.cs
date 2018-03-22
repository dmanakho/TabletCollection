namespace TabletCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImportID = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        NickName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        ClassOf = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tablets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TabletName = c.String(nullable: false, maxLength: 50),
                        SerialNo = c.String(nullable: false, maxLength: 20),
                        AssetTag = c.String(nullable: false, maxLength: 20),
                        CreatedBy = c.String(maxLength: 256),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        UpdatedOn = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tablets");
            DropTable("dbo.Students");
        }
    }
}
