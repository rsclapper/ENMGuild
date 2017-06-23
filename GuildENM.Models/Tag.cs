using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuildENM.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}