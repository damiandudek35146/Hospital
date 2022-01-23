using Hospital.DataLayer;
using Hospital.Domain.Entities;
using Hospital.Service.Controllers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Service.Controllers
{
    public class SpecialisationController : ISpecialisationController
    {
        public async Task<List<Specialisation>> GetAll()
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var treatments = await context.Specialisations.ToListAsync();
                    return treatments;
                }
                catch (Exception ex)
                {
                    return new List<Specialisation>();
                }
            }
        }
    }
}
