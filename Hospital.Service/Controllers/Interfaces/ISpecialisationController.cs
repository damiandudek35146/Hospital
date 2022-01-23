using Hospital.Domain.Entities;

namespace Hospital.Service.Controllers.Interfaces
{
    public interface ISpecialisationController
    {
        Task<List<Specialisation>> GetAll();
    }
}
