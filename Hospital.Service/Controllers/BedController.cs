using Hospital.DataLayer;
using Hospital.Domain.Entities;
using Hospital.Service.Controllers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Service.Controllers
{
    public class BedController : IBedController
    {
        public async Task<Bed> Get(int roomNumber, int bedNumber)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var beds = await context.Beds.Where(x => x.RoomNumber == roomNumber && x.BedNumber == bedNumber).ToListAsync();
                    return beds.First();
                }
                catch (Exception ex)
                {
                    return new Bed();
                }
            }
        }
    }
}
