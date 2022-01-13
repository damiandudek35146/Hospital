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
    public class BedConfiguration : IEntityTypeConfiguration<Bed>
    {
        public void Configure(EntityTypeBuilder<Bed> builder)
        {

            builder.Property(x => x.BedNumber)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.RoomNumber)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
