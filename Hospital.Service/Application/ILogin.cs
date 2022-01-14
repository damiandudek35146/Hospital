using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Application
{
    public interface ILogin
    {
        Task<Doctor> LoginDoctor(string login, string password);
    }
}
