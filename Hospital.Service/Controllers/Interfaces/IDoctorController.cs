using Hospital.Domain.Entities;

namespace Hospital.Service.Application
{
    public interface IDoctorController
    {
        Task<bool> Register(Doctor doctor);
        Task<Doctor> Login(string login, string password);
        Task Update(Doctor patient);
        Task<Doctor> Get(int Id);
        Task<bool> AddSpecialisation(Doctor doctor, Specialisation specialisation);
        Task<bool> RemoveSpecialisation(Doctor doctor, Specialisation specialisation);
    }
}
