namespace GuildENM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedDefaultContactId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "DefaultContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Contacts", new[] { "DefaultContactId" });
            AddColumn("dbo.Companies", "DefaultContactId", c => c.Int());
            AddColumn("dbo.Contacts", "Company_Id", c => c.Int());
            CreateIndex("dbo.Companies", "DefaultContactId");
            CreateIndex("dbo.Contacts", "Company_Id");
            AddForeignKey("dbo.Companies", "DefaultContactId", "dbo.Contacts", "Id");
            AddForeignKey("dbo.Contacts", "Company_Id", "dbo.Companies", "Id");
            DropColumn("dbo.Contacts", "DefaultContactId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "DefaultContactId", c => c.Int());
            DropForeignKey("dbo.Contacts", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Companies", "DefaultContactId", "dbo.Contacts");
            DropIndex("dbo.Contacts", new[] { "Company_Id" });
            DropIndex("dbo.Companies", new[] { "DefaultContactId" });
            DropColumn("dbo.Contacts", "Company_Id");
            DropColumn("dbo.Companies", "DefaultContactId");
            CreateIndex("dbo.Contacts", "DefaultContactId");
            AddForeignKey("dbo.Contacts", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "DefaultContactId", "dbo.Contacts", "Id");
        }
    }
}
