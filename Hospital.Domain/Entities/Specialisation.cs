namespace Hospital.Domain.Entities
{
    public class Specialisation : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    }
}