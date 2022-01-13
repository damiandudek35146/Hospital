using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
