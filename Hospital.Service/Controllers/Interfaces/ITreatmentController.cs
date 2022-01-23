using Hospital.Domain.Entities;

namespace Hospital.Service.Controllers
{
    public interface ITreatmentController
    {
        Task<bool> Add(Treatment treatment);
        Task<List<Treatment>> GetInFutureByPatientId(int Id);
        Task<List<Treatment>> GetInPastByPatientId(int Id);
        Task<List<Treatment>> GetInFutureByDoctorId(int Id);
        Task<List<Treatment>> GetInPastByDoctorId(int Id);
        Task<List<Treatment>> GetByPatientId(int Id);
    }
}
