using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildENM.Models
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime LastEdit { get; set; }

        public virtual Location Location { get; set; }
        public virtual List<Skill> Skills { get; set; }
        
    }
}
