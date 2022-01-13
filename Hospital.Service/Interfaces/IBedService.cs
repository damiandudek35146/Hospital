using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public interface IBedService
    {
        IEnumerable<Bed> GetBeds();
        Bed GetBed(int id);
        void InsertBed(Bed bed);
        void UpdateBed(Bed bed);
        void DeleteBed(int id);
    }
}
