using Hospital.DataLayer.Repositories;
using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class BedService : IBedService
    {
        private IRepository<Bed> userRepository;

        public BedService()
        {
            this.userRepository = new Repository<Bed>();
        }

        public IEnumerable<Bed> GetBeds()
        {
            return userRepository.GetAll();
            userRepository.SaveChanges();
        }

        public Bed GetBed(int id)
        {
            return userRepository.Get(id);
            userRepository.SaveChanges();
        }

        public void InsertBed(Bed bed)
        {
            userRepository.Insert(bed);
            userRepository.SaveChanges();
        }
        public void UpdateBed(Bed bed)
        {
            userRepository.Update(bed);
            userRepository.SaveChanges();
        }

        public void DeleteBed(int id)
        {
            Bed bed = GetBed(id);
            userRepository.Remove(bed);
            userRepository.SaveChanges();
        }
    }
}
