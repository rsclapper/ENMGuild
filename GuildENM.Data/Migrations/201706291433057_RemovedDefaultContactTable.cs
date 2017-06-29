namespace GuildENM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDefaultContactTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DefaultContacts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.DefaultContacts", "ContactId", "dbo.Contacts");
            DropIndex("dbo.DefaultContacts", new[] { "CompanyId" });
            DropIndex("dbo.DefaultContacts", new[] { "ContactId" });
            AddColumn("dbo.Contacts", "DefaultContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "DefaultContactId");
            AddForeignKey("dbo.Contacts", "DefaultContactId", "dbo.Contacts", "Id");
            DropTable("dbo.DefaultContacts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DefaultContacts",
                c => new
                    {
                        CompanyId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            DropForeignKey("dbo.Contacts", "DefaultContactId", "dbo.Contacts");
            DropIndex("dbo.Contacts", new[] { "DefaultContactId" });
            DropColumn("dbo.Contacts", "DefaultContactId");
            CreateIndex("dbo.DefaultContacts", "ContactId");
            CreateIndex("dbo.DefaultContacts", "CompanyId");
            AddForeignKey("dbo.DefaultContacts", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DefaultContacts", "CompanyId", "dbo.Companies", "Id");
        }
    }
}
