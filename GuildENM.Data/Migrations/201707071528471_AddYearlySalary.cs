namespace GuildENM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYearlySalary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobHistories", "YearlySalary", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobHistories", "YearlySalary");
        }
    }
}
