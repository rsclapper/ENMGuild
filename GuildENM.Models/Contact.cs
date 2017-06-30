using System.ComponentModel.DataAnnotations.Schema;

namespace GuildENM.Models
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual Company Company { get; set; }
    }

    
}