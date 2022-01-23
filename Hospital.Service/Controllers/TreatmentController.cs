using Hospital.DataLayer;
using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Service.Controllers
{
    public class TreatmentController : ITreatmentController
    {
        public async Task<List<Treatment>> GetInFutureByPatientId(int Id)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var treatments = await context.Treatments
                        .Where(t => t.StartsAt > DateTime.Now)
                        .Where(t => t.PatientId == Id)
                        .Include(x => x.Doctor)
                        .Include(x => x.Bed)
                        .ToListAsync();
                    return treatments;
                }
                catch (Exception ex)
                {
                    return new List<Treatment>();
                }
            }
        }
        public async Task<List<Treatment>> GetInFutureByDoctorId(int Id)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var treatments = await context.Treatments
                        .Where(t => t.StartsAt > DateTime.Now)
                        .Where(t => t.DoctorId == Id)
                        .Include(x => x.Patient)
                        .Include(x => x.Bed)
                        .ToListAsync();
                    return treatments;
                }
                catch (Exception ex)
                {
                    return new List<Treatment>();
                }
            }
        }
        public async Task<List<Treatment>> GetInPastByPatientId(int Id)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var treatments = await context.Treatments
                        .Where(t => t.StartsAt <= DateTime.Now)
                        .Where(t => t.PatientId == Id)
                        .Include(x => x.Doctor)
                        .Include(x => x.Bed)
                        .ToListAsync();
                    return treatments;
                }
                catch (Exception ex)
                {
                    return new List<Treatment>();
                }
            }
        }
        public async Task<List<Treatment>> GetInPastByDoctorId(int Id)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var treatments = await context.Treatments
                        .Where(t => t.StartsAt <= DateTime.Now)
                        .Where(t => t.DoctorId == Id)
                        .Include(x => x.Patient)
                        .Include(x => x.Bed)
                        .ToListAsync();
                    return treatments;
                }
                catch (Exception ex)
                {
                    return new List<Treatment>();
                }
            }
        }
        public async Task<List<Treatment>> GetByPatientId(int Id)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var treatments = await context.Treatments
                        .Where(t => t.PatientId == Id)
                        .Include(x => x.Doctor)
                        .Include(x => x.Bed)
                        .ToListAsync();
                    return treatments;
                }
                catch (Exception ex)
                {
                    return new List<Treatment>();
                }
            }
        }
        public async Task<bool> Add(Treatment treatment)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    context.Treatments.Add(treatment);
                    await context.SaveChangesAsync();
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
