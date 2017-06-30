using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildENM.Models
{
    public class Note : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [ForeignKey("EmploymentManager")]
        public string EmploymentManagerId { get; set; }

        [ForeignKey("EmploymentManagerId")]
        public EmploymentManager EmploymentManager { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public StudentUser Student { get; set; }
    }
}