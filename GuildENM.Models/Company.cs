using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildENM.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Contact> Contacts {get;set;}
        public virtual ICollection<Location> Locations {get;set; }
    }
   
    public class Contact
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int? DefaultContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual Company Company { get; set; }
        public virtual Contact DefaultContact { get; set; }
    }

    
}