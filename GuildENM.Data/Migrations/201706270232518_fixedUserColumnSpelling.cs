namespace GuildENM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedUserColumnSpelling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            DropColumn("dbo.AspNetUsers", "FristName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "FristName", c => c.String());
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
