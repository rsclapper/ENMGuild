using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildENM.Models
{
    public class Company : IEntity
    {
        public Company()
        {
            this.Posts = new List<Post>();
            this.Contacts = new List<Contact>();
            this.Locations = new List<Location>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public int? DefaultContactId { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Contact> Contacts {get;set;}
        public virtual ICollection<Location> Locations {get;set; }
        [ForeignKey("DefaultContactId")]
        public virtual Contact DefaultContact { get; set; }
    }

    
}