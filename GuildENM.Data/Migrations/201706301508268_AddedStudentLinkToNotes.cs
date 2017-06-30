namespace GuildENM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStudentLinkToNotes : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Notes", new[] { "EmploymentManagerId" });
            RenameColumn(table: "dbo.Notes", name: "StudentUser_Id", newName: "StudentId");
            RenameIndex(table: "dbo.Notes", name: "IX_StudentUser_Id", newName: "IX_StudentId");
            DropPrimaryKey("dbo.Notes");
            AlterColumn("dbo.Notes", "EmploymentManagerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Notes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Notes", "Id");
            CreateIndex("dbo.Notes", "EmploymentManagerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Notes", new[] { "EmploymentManagerId" });
            DropPrimaryKey("dbo.Notes");
            AlterColumn("dbo.Notes", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Notes", "EmploymentManagerId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Notes", "EmploymentManagerId");
            RenameIndex(table: "dbo.Notes", name: "IX_StudentId", newName: "IX_StudentUser_Id");
            RenameColumn(table: "dbo.Notes", name: "StudentId", newName: "StudentUser_Id");
            CreateIndex("dbo.Notes", "EmploymentManagerId");
        }
    }
}
