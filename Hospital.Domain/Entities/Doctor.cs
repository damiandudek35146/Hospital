namespace Hospital.Domain.Entities
{
    public class Doctor : User
    {
        public Doctor()
        {
            
        }
        public ContactInfo ContactInfo { get; set; }
        public ICollection<Treatment> Treatments { get; set; } = new HashSet<Treatment>();
        public ICollection<Specialisation> Specialisations { get; set; } = new HashSet<Specialisation>();

    }
}
