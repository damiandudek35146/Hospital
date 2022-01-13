using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IContactInfoService
    {   
        IEnumerable<ContactInfo> GetContactInfos();
        ContactInfo GetContactInfo(int id);
        void InsertContactInfo(ContactInfo contactInfo);
        void UpdateContactInfo(ContactInfo contactInfo);
        void DeleteContactInfo(int id);
    }
}
