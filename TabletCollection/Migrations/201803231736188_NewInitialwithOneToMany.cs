namespace TabletCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewInitialwithOneToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsStylus = c.Boolean(nullable: false),
                        IsAC = c.Boolean(nullable: false),
                        IsNegligence = c.Boolean(nullable: false),
                        ChargeNotes = c.String(),
                        Comments = c.String(),
                        TabletID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        UpdatedOn = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .ForeignKey("dbo.Tablets", t => t.TabletID)
                .Index(t => t.TabletID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImportID = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        NickName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        ForeignExchangeBound = c.Boolean(),
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
                        IsPurchased = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        UpdatedOn = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.SerialNo, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Collections", "TabletID", "dbo.Tablets");
            DropForeignKey("dbo.Collections", "StudentID", "dbo.Students");
            DropIndex("dbo.Tablets", new[] { "SerialNo" });
            DropIndex("dbo.Collections", new[] { "StudentID" });
            DropIndex("dbo.Collections", new[] { "TabletID" });
            DropTable("dbo.Tablets");
            DropTable("dbo.Students");
            DropTable("dbo.Collections");
        }
    }
}
