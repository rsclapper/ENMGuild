using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildENM.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime LastEdit { get; set; }

        public List<Comment> Comments { get; set; }
        public Company Company { get; set; }
        public Location Location { get; set; }

    }
}
