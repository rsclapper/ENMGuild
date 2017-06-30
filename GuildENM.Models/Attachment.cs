using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuildENM.Models
{
    public class Attachment : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int AttachmentTypeId { get; set; }
        [Key]
        public string StudentUserId { get; set; }

        [ForeignKey("StudentUserId")]
        public virtual StudentUser StudentUser { get; set; }

    }

    public class AttachmentType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}