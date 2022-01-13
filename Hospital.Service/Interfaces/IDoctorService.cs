using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetDoctors();
        Doctor GetDoctor(int id);
        void InsertDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(int id);
    }
}
