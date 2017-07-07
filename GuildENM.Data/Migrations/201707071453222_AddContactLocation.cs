namespace GuildENM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "LocationId", c => c.Int());
            CreateIndex("dbo.Contacts", "LocationId");
            AddForeignKey("dbo.Contacts", "LocationId", "dbo.Locations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "LocationId", "dbo.Locations");
            DropIndex("dbo.Contacts", new[] { "LocationId" });
            DropColumn("dbo.Contacts", "LocationId");
        }
    }
}
