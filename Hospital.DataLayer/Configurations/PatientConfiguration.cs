using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.DataLayer.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.IdCardNumber)
                .IsRequired()
                .HasMaxLength(15);
            builder.HasIndex(x => x.Login)
                .IsUnique();
            builder.Property(x => x.BedId);
        }
    }

}
