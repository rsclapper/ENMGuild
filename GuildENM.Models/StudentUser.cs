using System;
using System.Collections.Generic;

namespace GuildENM.Models
{
    public class StudentUser : ApplicationUser
    {
        public DateTime GraudationDate { get; set; } 
        public string ProfileUrl { get; set; }

        public virtual ICollection<JobHistory> JobHistories { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public virtual EmploymentManager EmploymentManager { get; set; }
    }
}