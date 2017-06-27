namespace GuildENM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedTagsToSkills_AddedStudentENM : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tags", newName: "Skills");
            RenameTable(name: "dbo.TagPosts", newName: "SkillPosts");
            RenameColumn(table: "dbo.SkillPosts", name: "Tag_Id", newName: "Skill_Id");
            RenameIndex(table: "dbo.SkillPosts", name: "IX_Tag_Id", newName: "IX_Skill_Id");
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StudentUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentUser_Id)
                .Index(t => t.StudentUser_Id);
            
            CreateTable(
                "dbo.CourseSkills",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        Skill_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Skill_Id })
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.Skill_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.Skill_Id);
            
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "EmploymentManager_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "EmploymentManager_Id");
            AddForeignKey("dbo.AspNetUsers", "EmploymentManager_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "EmploymentManager_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "StudentUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseSkills", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.CourseSkills", "Course_Id", "dbo.Courses");
            DropIndex("dbo.CourseSkills", new[] { "Skill_Id" });
            DropIndex("dbo.CourseSkills", new[] { "Course_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "EmploymentManager_Id" });
            DropIndex("dbo.Courses", new[] { "StudentUser_Id" });
            DropColumn("dbo.AspNetUsers", "EmploymentManager_Id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropTable("dbo.CourseSkills");
            DropTable("dbo.Courses");
            RenameIndex(table: "dbo.SkillPosts", name: "IX_Skill_Id", newName: "IX_Tag_Id");
            RenameColumn(table: "dbo.SkillPosts", name: "Skill_Id", newName: "Tag_Id");
            RenameTable(name: "dbo.SkillPosts", newName: "TagPosts");
            RenameTable(name: "dbo.Skills", newName: "Tags");
        }
    }
}
