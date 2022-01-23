namespace Hospital.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string IdCardNumber { get; set; }
        public int? ContactInfoId { get; set; }
    }
}
