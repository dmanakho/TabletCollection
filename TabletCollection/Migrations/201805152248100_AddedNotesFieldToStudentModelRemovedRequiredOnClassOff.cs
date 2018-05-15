namespace TabletCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNotesFieldToStudentModelRemovedRequiredOnClassOff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Notes", c => c.String(maxLength: 500));
            AlterColumn("dbo.Students", "ClassOf", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "ClassOf", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "Notes");
        }
    }
}
