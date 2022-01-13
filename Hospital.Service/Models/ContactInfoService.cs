using Hospital.DataLayer.Repositories;
using Hospital.Domain.Entities;
using Hospital.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Models
{
    public class ContactInfoService : IContactInfoService
    {
        private IRepository<ContactInfo> userRepository;

        public ContactInfoService()
        {
            this.userRepository = new Repository<ContactInfo>();
        }

        public IEnumerable<ContactInfo> GetContactInfos()
        {
            return userRepository.GetAll();
            userRepository.SaveChanges();
        }

        public ContactInfo GetContactInfo(int id)
        {
            return userRepository.Get(id);
            userRepository.SaveChanges();
        }

        public void InsertContactInfo(ContactInfo contactInfo)
        {
            userRepository.Insert(contactInfo);
            userRepository.SaveChanges();
        }
        public void UpdateContactInfo(ContactInfo contactInfo)
        {
            userRepository.Update(contactInfo);
            userRepository.SaveChanges();
        }

        public void DeleteContactInfo(int id)
        {
            ContactInfo contactInfo = GetContactInfo(id);
            userRepository.Remove(contactInfo);
            userRepository.SaveChanges();
        }
    }
}
