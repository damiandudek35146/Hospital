using Blog.DataLayer.Extensions;
using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Hospital.DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialisation> Specialisations { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Bed> Beds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Using singleton
            var instance = ConnectionStringSingleton.GetInstance();
            optionsBuilder.UseSqlServer(instance.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.SeedBeds();
            modelBuilder.SeedSpecialisations();
        }
    }
}
