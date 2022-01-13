using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface ISpecialisationService
    {
        IEnumerable<Specialisation> GetSpecialisations();
        Specialisation GetSpecialisation(int id);
        void InsertSpecialisation(Specialisation specialisation);
        void UpdateSpecialisation(Specialisation specialisation);
        void DeleteSpecialisation(int id);
    }
}
