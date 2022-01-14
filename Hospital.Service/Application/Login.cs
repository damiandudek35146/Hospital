using Hospital.DataLayer;
using Hospital.Domain.Entities;
using Hospital.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Application
{
    public class Login : ILogin
    {
        public async Task<Doctor> LoginDoctor(string login, string password)
        {
            using (var context = new ApplicationDbContext())
            {
                var doctor = await context.Doctor.Where(x=>x.Login==login&&x.Password==password).ToListAsync();
                return doctor.First();
            }
        }
    }
}
