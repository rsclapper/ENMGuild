using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GuildENM.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }

   
}