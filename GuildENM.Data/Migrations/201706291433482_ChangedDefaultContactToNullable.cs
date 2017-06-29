namespace GuildENM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDefaultContactToNullable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Contacts", new[] { "DefaultContactId" });
            AlterColumn("dbo.Contacts", "DefaultContactId", c => c.Int());
            CreateIndex("dbo.Contacts", "DefaultContactId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contacts", new[] { "DefaultContactId" });
            AlterColumn("dbo.Contacts", "DefaultContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "DefaultContactId");
        }
    }
}
