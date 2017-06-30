using System.Collections.Generic;

namespace GuildENM.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}