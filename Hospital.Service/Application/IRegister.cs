using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Application
{
    public interface IRegister
    {
        void RegisterDoctor(Doctor doctor);
        void RegisterPatient(Patient patient);
    }
}
