namespace GuildENM.Data.Migrations
{
    using GuildENM.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildENM.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildENM.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            EmploymentManager enmManager = context.EmploymentManager.FirstOrDefault(u => u.UserName == "testENM@test.com");
            if (enmManager == null)
            {

                enmManager = new EmploymentManager { UserName = "testENM@test.com", Email = "testENM@test.com", FirstName = "Test", LastName = "Manager" };
                userManager.Create(enmManager, "Password@123");
            }

            if (!(context.Users.Any(u => u.UserName == "testStudent@test.com")))
            {

                var userToInsert = new StudentUser { UserName = "testStudent@test.com", Email = "testStudent@test.com", FirstName = "Test", LastName = "Student", EmploymentManager = enmManager };
                userManager.Create(userToInsert, "Password@123");
            }
        }
    }
}
