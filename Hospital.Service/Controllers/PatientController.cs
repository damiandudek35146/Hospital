using Hospital.DataLayer;
using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Service.Application
{
    public class PatientController : IPatientController
    {
        public async Task<Patient> Login(string login, string password)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var patients = await context.Patients
                        .Where(x => x.Login == login && x.Password == password)
                        .Include(x => x.Treatments)
                        .Include(x => x.Bed)
                        .Include(x => x.ContactInfo)
                        .ToListAsync();
                    return patients.First();
                }
                catch (Exception ex)
                {
                    return new Patient();
                }
            }
        }
        public async Task<Patient> Get(int Id)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var patients = await context.Patients
                        .Where(x => x.Id == Id)
                        .Include(x => x.Treatments)
                        .Include(x => x.Bed)
                        .Include(x => x.ContactInfo)
                        .ToListAsync();
                    return patients.First();
                }
                catch (Exception ex)
                {
                    return new Patient();
                }
            }
        }
        public async Task<bool> Register(Patient patient)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    context.Patients.Add(patient);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public async Task Update(Patient patient)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    context.Patients.Update(patient);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                }
            }
        }
        public async Task<bool> Delete(Patient patient)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    context.Patients.Remove(patient);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public async Task<List<Patient>> GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var patients = await context.Patients
                        .Include(x => x.Treatments)
                        .Include(x => x.Bed)
                        .Include(x => x.ContactInfo)
                        .ToListAsync();
                    return patients;
                }
                catch (Exception ex)
                {
                    return new List<Patient>();
                }
            }
        }
    }
}
