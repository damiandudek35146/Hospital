using Hospital.DataLayer.Repositories;
using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class PatientService : IPatientService
    {
        private IRepository<Patient> userRepository;

        public PatientService()
        {
            this.userRepository = new Repository<Patient>();
        }

        public IEnumerable<Patient> GetPatients()
        {
            return userRepository.GetAll();
            userRepository.SaveChanges();
        }

        public Patient GetPatient(int id)
        {
            return userRepository.Get(id);
            userRepository.SaveChanges();
        }

        public void InsertPatient(Patient patient)
        {
            userRepository.Insert(patient);
            userRepository.SaveChanges();
        }
        public void UpdatePatient(Patient patient)
        {
            userRepository.Update(patient);
            userRepository.SaveChanges();
        }

        public void DeletePatient(int id)
        {
            Patient patient = GetPatient(id);
            userRepository.Remove(patient);
            userRepository.SaveChanges();
        }
    }
}
