using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.DataLayer.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedBeds(this ModelBuilder modelBuilder)
        {
            var beds = new List<Bed>();
            int id = 1;
            for (int i = 1; i <= 100; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    var bed = new Bed();
                    bed.RoomNumber = i;
                    bed.BedNumber = j;
                    bed.Id = id;
                    beds.Add(bed);
                    id++;
                }
            }
            var myBed = new Bed { Id = 4, BedNumber = 4, RoomNumber = 4 };
            
            modelBuilder.Entity<Bed>().HasData(beds.ToArray());
        }
        public static void SeedSpecialisations(this ModelBuilder modelBuilder)
        {
            var specialisations = new List<Specialisation>();
            specialisations.Add(new Specialisation { Id = 1, Name = "Allergy and immunology" });
            specialisations.Add(new Specialisation { Id = 2, Name = "Anesthesiology" });
            specialisations.Add(new Specialisation { Id = 3, Name = "Dermatology" });
            specialisations.Add(new Specialisation { Id = 4, Name = "Diagnostic radiology" });
            specialisations.Add(new Specialisation { Id = 5, Name = "Emergency medicine" });
            specialisations.Add(new Specialisation { Id = 6, Name = "Family medicine" });
            specialisations.Add(new Specialisation { Id = 7, Name = "Internal medicine" });
            specialisations.Add(new Specialisation { Id = 8, Name = "Medical genetics" });
            specialisations.Add(new Specialisation { Id = 9, Name = "Neurology" });
            specialisations.Add(new Specialisation { Id = 10, Name = "Nuclear medicine" });
            specialisations.Add(new Specialisation { Id = 11, Name = "Obstetrics and gynecology" });
            specialisations.Add(new Specialisation { Id = 12, Name = "Ophthalmology" });
            specialisations.Add(new Specialisation { Id = 13, Name = "Pathology" });
            specialisations.Add(new Specialisation { Id = 14, Name = "Pediatrics" });
            specialisations.Add(new Specialisation { Id = 15, Name = "Physical medicine and rehabilitation" });
            specialisations.Add(new Specialisation { Id = 16, Name = "Preventive medicine" });
            specialisations.Add(new Specialisation { Id = 17, Name = "Psychiatry" });
            specialisations.Add(new Specialisation { Id = 18, Name = "Radiation oncology" });
            specialisations.Add(new Specialisation { Id = 19, Name = "Surgery" });
            specialisations.Add(new Specialisation { Id = 20, Name = "Urology" });
            modelBuilder.Entity<Specialisation>().HasData(specialisations.ToArray());
        }
    }
}
