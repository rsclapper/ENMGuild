using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GuildENM.Models
{
    public interface IEntity
    {
         int Id { get; set; }
    }
    public class Skill : IEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }

   
}