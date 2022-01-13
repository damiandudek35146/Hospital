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
    public class TreatmentService : ITreatmentService
    {
        private IRepository<Treatment> userRepository;

        public TreatmentService()
        {
            this.userRepository = new Repository<Treatment>();
        }

        public IEnumerable<Treatment> GetTreatments()
        {
            return userRepository.GetAll();
            userRepository.SaveChanges();
        }

        public Treatment GetTreatment(int id)
        {
            return userRepository.Get(id);
            userRepository.SaveChanges();
        }

        public void InsertTreatment(Treatment treatment)
        {
            userRepository.Insert(treatment);
            userRepository.SaveChanges();
        }
        public void UpdateTreatment(Treatment treatment)
        {
            userRepository.Update(treatment);
            userRepository.SaveChanges();
        }

        public void DeleteTreatment(int id)
        {
            Treatment treatment = GetTreatment(id);
            userRepository.Remove(treatment);
            userRepository.SaveChanges();
        }
    }
}
