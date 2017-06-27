﻿using System;
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
        public DbSet<Post> Posts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DefaultContact> DefaultContacts { get; set; }
        public DbSet<Skill> Tags { get; set; }
        public DbSet<StudentUser> StudentUsers { get; set; }
        public DbSet<EmploymentManager> EmploymentManager { get; set; }
    }
}
