namespace GuildENM.Models
{
    public class Location : IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public virtual Company Company { get; set; }
    }
}