namespace Hospital.Domain.Entities
{
    public class Bed : BaseEntity
    {
        public int BedNumber { get; set; }
        public int RoomNumber { get; set; }
        public Patient Patient { get; set; }
    }
}