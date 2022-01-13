using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string IdCardNumber { get; set; }
        public int ContactInfoId { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public ICollection<Treatment> Treatments { get; set; } = new HashSet<Treatment>();
        public ICollection<Specialisation> Specialisations { get; set; } = new HashSet<Specialisation>();

    }
}
