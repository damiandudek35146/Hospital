using Hospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospital.DataLayer.Configurations
{
    public class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(12);
        }
    }
}
