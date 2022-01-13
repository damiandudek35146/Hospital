using Blog.DataLayer.Extensions;
using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        //public DbSet<User> Users { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Specialisation> Specialisations { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Bed> Beds { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true);
            var config = builder.Build();
            optionsBuilder.UseSqlServer(config["ConnectionString"]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.SeedBeds();
            //modelBuilder.SeedSpecialisations();
        }
    }
}
