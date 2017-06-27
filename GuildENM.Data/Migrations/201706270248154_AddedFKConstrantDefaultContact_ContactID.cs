namespace GuildENM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFKConstrantDefaultContact_ContactID : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.DefaultContacts", "ContactId");
            AddForeignKey("dbo.DefaultContacts", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DefaultContacts", "ContactId", "dbo.Contacts");
            DropIndex("dbo.DefaultContacts", new[] { "ContactId" });
        }
    }
}
