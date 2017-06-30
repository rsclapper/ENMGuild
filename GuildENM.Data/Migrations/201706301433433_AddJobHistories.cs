namespace GuildENM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobHistories : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SkillPosts", newName: "PostSkills");
            RenameTable(name: "dbo.CourseSkills", newName: "SkillCourses");
            DropPrimaryKey("dbo.PostSkills");
            DropPrimaryKey("dbo.SkillCourses");
            AddPrimaryKey("dbo.PostSkills", new[] { "Post_Id", "Skill_Id" });
            AddPrimaryKey("dbo.SkillCourses", new[] { "Skill_Id", "Course_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.SkillCourses");
            DropPrimaryKey("dbo.PostSkills");
            AddPrimaryKey("dbo.SkillCourses", new[] { "Course_Id", "Skill_Id" });
            AddPrimaryKey("dbo.PostSkills", new[] { "Skill_Id", "Post_Id" });
            RenameTable(name: "dbo.SkillCourses", newName: "CourseSkills");
            RenameTable(name: "dbo.PostSkills", newName: "SkillPosts");
        }
    }
}
