using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetPatients();
        Patient GetPatient(int id);
        void InsertPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int id);
    }
}
