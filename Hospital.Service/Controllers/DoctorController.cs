using Hospital.DataLayer;
using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Service.Application
{
    public class DoctorController : IDoctorController
    {
        // Example of asynchronous method
        public async Task<Doctor> Login(string login, string password)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var doctors = await context.Doctors.Where(x => x.Login == login && x.Password == password).ToListAsync();
                    return doctors.First();
                }
                catch (Exception ex)
                {
                    return new Doctor();
                }
            }
        }

        public async Task<bool> Register(Doctor doctor)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    context.Doctors.Add(doctor);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
        }
        public async Task<Doctor> Get(int Id)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var patients = await context.Doctors
                        .Where(x => x.Id == Id)
                        .Include(x => x.Treatments)
                        .Include(x => x.Specialisations)
                        .Include(x => x.ContactInfo)
                        .ToListAsync();
                    return patients.First();
                }
                catch (Exception ex)
                {
                    return new Doctor();
                }
            }
        }
        public async Task Update(Doctor doctor)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Update(doctor);
                context.SaveChanges();
            }
        }
        public async Task<bool> AddSpecialisation(Doctor doctor, Specialisation specialisation)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var doc = await context.Doctors.SingleOrDefaultAsync(x => x.Id == doctor.Id);
                    doc.Specialisations.Add(specialisation);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public async Task<bool> RemoveSpecialisation(Doctor doctor, Specialisation specialisation)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var doc = context.Doctors.Where(x => x.Id == doctor.Id).Include(x => x.Specialisations).ToListAsync().Result.First();
                    doc.Specialisations = doc.Specialisations.Where(x => x.Name != specialisation.Name).ToList();
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
