using Hospital.Domain.Entities;

namespace Hospital.Service.Controllers.Interfaces
{
    public interface IBedController
    {
        Task<Bed> Get(int roomNumber, int bedNumber);
    }
}
