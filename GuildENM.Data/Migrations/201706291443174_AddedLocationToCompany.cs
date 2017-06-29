namespace GuildENM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLocationToCompany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Posts", new[] { "CompanyId" });
            RenameColumn(table: "dbo.Posts", name: "CompanyId", newName: "Company_Id");
            AddColumn("dbo.Locations", "CompanyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "Company_Id", c => c.Int());
            CreateIndex("dbo.Locations", "CompanyId");
            CreateIndex("dbo.Posts", "Company_Id");
            AddForeignKey("dbo.Locations", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "Company_Id", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Locations", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Posts", new[] { "Company_Id" });
            DropIndex("dbo.Locations", new[] { "CompanyId" });
            AlterColumn("dbo.Posts", "Company_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Locations", "CompanyId");
            RenameColumn(table: "dbo.Posts", name: "Company_Id", newName: "CompanyId");
            CreateIndex("dbo.Posts", "CompanyId");
            AddForeignKey("dbo.Posts", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
    }
}
