using System.Collections.Generic;

namespace GuildENM.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }

    }
}