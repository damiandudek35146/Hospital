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
    internal class SpecialisationService : ISpecialisationService
    {
        private IRepository<Specialisation> userRepository;

        public SpecialisationService()
        {
            this.userRepository = new Repository<Specialisation>();
        }

        public IEnumerable<Specialisation> GetSpecialisations()
        {
            return userRepository.GetAll();
            userRepository.SaveChanges();
        }

        public Specialisation GetSpecialisation(int id)
        {
            return userRepository.Get(id);
            userRepository.SaveChanges();
        }

        public void InsertSpecialisation(Specialisation specialisation)
        {
            userRepository.Insert(specialisation);
            userRepository.SaveChanges();
        }
        public void UpdateSpecialisation(Specialisation specialisation)
        {
            userRepository.Update(specialisation);
            userRepository.SaveChanges();
        }

        public void DeleteSpecialisation(int id)
        {
            Specialisation specialisation = GetSpecialisation(id);
            userRepository.Remove(specialisation);
            userRepository.SaveChanges();
        }
    }
}
