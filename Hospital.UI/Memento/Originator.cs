using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    // The Originator class can produce snapshots of its own state, as well as restore its state from snapshots when needed.
    public class Originator
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdCardNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Memento CreateMemento()
        {
            return (new Memento(FirstName, LastName, IdCardNumber, Email, PhoneNumber));
        }
        public void SetMemento(Memento memento)
        {
            FirstName = memento.FirstName;
            LastName = memento.LastName;
            IdCardNumber = memento.IdCardNumber;
            Email = memento.Email;
            PhoneNumber = memento.PhoneNumber;
        }
    }
}
