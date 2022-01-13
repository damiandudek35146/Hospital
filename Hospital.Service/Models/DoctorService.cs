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

    public class DoctorService : IDoctorService
    {
        private IRepository<Doctor> userRepository;

        public DoctorService()
        {
            this.userRepository = new Repository<Doctor>();
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return userRepository.GetAll();
            userRepository.SaveChanges();
        }

        public Doctor GetDoctor(int id)
        {
            return userRepository.Get(id);
            userRepository.SaveChanges();
        }

        public void InsertDoctor(Doctor doctor)
        {
            userRepository.Insert(doctor);
            userRepository.SaveChanges();
        }
        public void UpdateDoctor(Doctor doctor)
        {
            userRepository.Update(doctor);
            userRepository.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            Doctor doctor = GetDoctor(id);
            userRepository.Remove(doctor);
            userRepository.SaveChanges();
        }
    }
}
