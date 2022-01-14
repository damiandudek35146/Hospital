using Hospital.DataLayer;
using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Application
{
    public class Register : IRegister
    {
        public async void RegisterDoctor(Doctor doctor)
        {
            using (var context = new ApplicationDbContext())
            {
               context.Doctors.Add(doctor);
               await context.SaveChangesAsync();
            }
        }

        public async void RegisterPatient(Patient patient)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Patients.Add(patient);
                await context.SaveChangesAsync();
            }
        }
    }
}
