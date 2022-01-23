namespace Hospital.UI
{
    // This is representation of user memento it is a parto of Memento pattern.
    // The Memento is a value object that acts as a snapshot of the originator’s state.
    public class Memento
    {
        public string FirstName { get;}
        public string LastName { get;}
        public string IdCardNumber { get;}
        public string Email { get;}
        public string PhoneNumber { get;}
        public Memento(string FirstName, string LastName, string IdCardNumber, string Email, string PhoneNumber)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.IdCardNumber = IdCardNumber;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
        }
    }
}