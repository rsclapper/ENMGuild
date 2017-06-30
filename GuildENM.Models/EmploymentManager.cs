using System.Collections.Generic;

namespace GuildENM.Models
{
    public class EmploymentManager : ApplicationUser
    {
        public virtual ICollection<StudentUser> Students { get; set; }
    }
}