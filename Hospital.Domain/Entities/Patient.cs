namespace Hospital.Domain.Entities
{
    public class Patient : User
    {
        public Patient()
        {
            Healthy = false;
            Dead = false;
        }
        public int? BedId { get; set; }
        public bool Healthy { get; set; }
        public bool Dead { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public Bed? Bed { get; set; }
        public ICollection<Treatment> Treatments { get; set; } = new HashSet<Treatment>();
    }
}
