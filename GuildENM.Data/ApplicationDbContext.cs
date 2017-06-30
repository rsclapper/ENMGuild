using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildENM.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GuildENM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder mb)
        {
            mb.Entity<Company>().HasMany(m => m.Contacts).WithRequired(m => m.Company).HasForeignKey(r=> r.CompanyId);
            base.OnModelCreating(mb);
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Skill> Tags { get; set; }
        public DbSet<StudentUser> StudentUsers { get; set; }
        public DbSet<EmploymentManager> EmploymentManager { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<JobHistory> JobHistories { get; set; }

        public System.Data.Entity.DbSet<GuildENM.Models.Note> Notes { get; set; }
    }
}
