using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.DataLayer.Configurations
{
    public class UTreatmentConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.HasOne(x => x.Patient)
                .WithMany(x => x.Treatments);
            builder.Property(x => x.PatientId)
                .IsRequired();
            builder.Property(x => x.BedId)
                .IsRequired();
        }
    }
}
