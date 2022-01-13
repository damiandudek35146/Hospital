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
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
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
        }
    }
}
