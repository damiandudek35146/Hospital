namespace Hospital.Domain.Entities
{
    public class Treatment : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DurationInHours { get; set; }
        public int BedId { get; set; }
        public Bed Bed { get; set; }
        //public int DoctorId { get; set; }
        //public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}