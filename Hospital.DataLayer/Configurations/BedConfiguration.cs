using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
