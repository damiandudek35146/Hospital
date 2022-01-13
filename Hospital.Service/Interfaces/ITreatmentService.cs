using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface ITreatmentService
    {
        IEnumerable<Treatment> GetTreatments();
        Treatment GetTreatment(int id);
        void InsertTreatment(Treatment treatment);
        void UpdateTreatment(Treatment treatment);
        void DeleteTreatment(int id);
    }
}
