using Hospital.Domain.Entities;

namespace Hospital.Service.Application
{
    public interface IPatientController
    {
        Task<bool> Register(Patient patient);
        Task<Patient> Login(string login, string password);
        Task Update(Patient patient);
        Task<bool> Delete(Patient patient);
        Task<Patient> Get(int Id);
        Task<List<Patient>> GetAll();
    }
}
