namespace TabletCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCollectoinandOnetoOneRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsStylus = c.Boolean(nullable: false),
                        IsAC = c.Boolean(nullable: false),
                        IsNegligence = c.Boolean(nullable: false),
                        Comments = c.String(),
                        CreatedBy = c.String(maxLength: 256),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        UpdatedOn = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tablets", t => t.Id)
                .ForeignKey("dbo.Students", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Collections", "Id", "dbo.Students");
            DropForeignKey("dbo.Collections", "Id", "dbo.Tablets");
            DropIndex("dbo.Collections", new[] { "Id" });
            DropTable("dbo.Collections");
        }
    }
}
