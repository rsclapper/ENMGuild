namespace GuildENM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentPofile : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SkillPosts", newName: "PostSkills");
            RenameTable(name: "dbo.CourseSkills", newName: "SkillCourses");
            DropPrimaryKey("dbo.PostSkills");
            DropPrimaryKey("dbo.SkillCourses");
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        StudentUserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Path = c.String(),
                        AttachmentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentUserId)
                .Index(t => t.StudentUserId);
            
            CreateTable(
                "dbo.JobHistories",
                c => new
                    {
                        StudentUserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        CompanyName = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.StudentUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentUserId)
                .Index(t => t.StudentUserId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        EmploymentManagerId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        Content = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        StudentUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmploymentManagerId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmploymentManagerId)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentUser_Id)
                .Index(t => t.EmploymentManagerId)
                .Index(t => t.StudentUser_Id);
            
            AddColumn("dbo.AspNetUsers", "GraudationDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "ProfileUrl", c => c.String());
            AddPrimaryKey("dbo.PostSkills", new[] { "Post_Id", "Skill_Id" });
            AddPrimaryKey("dbo.SkillCourses", new[] { "Skill_Id", "Course_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "StudentUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notes", "EmploymentManagerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobHistories", "StudentUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attachments", "StudentUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Notes", new[] { "StudentUser_Id" });
            DropIndex("dbo.Notes", new[] { "EmploymentManagerId" });
            DropIndex("dbo.JobHistories", new[] { "StudentUserId" });
            DropIndex("dbo.Attachments", new[] { "StudentUserId" });
            DropPrimaryKey("dbo.SkillCourses");
            DropPrimaryKey("dbo.PostSkills");
            DropColumn("dbo.AspNetUsers", "ProfileUrl");
            DropColumn("dbo.AspNetUsers", "GraudationDate");
            DropTable("dbo.Notes");
            DropTable("dbo.JobHistories");
            DropTable("dbo.Attachments");
            AddPrimaryKey("dbo.SkillCourses", new[] { "Course_Id", "Skill_Id" });
            AddPrimaryKey("dbo.PostSkills", new[] { "Skill_Id", "Post_Id" });
            RenameTable(name: "dbo.SkillCourses", newName: "CourseSkills");
            RenameTable(name: "dbo.PostSkills", newName: "SkillPosts");
        }
    }
}
