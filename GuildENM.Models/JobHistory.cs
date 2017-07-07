using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildENM.Models
{
    public class JobHistory : IEntity
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? YearlySalary { get; set; }

        [Key]
        public string StudentUserId { get; set; }

        [ForeignKey("StudentUserId")]
        public virtual StudentUser StudentUser { get; set; }
    }
}