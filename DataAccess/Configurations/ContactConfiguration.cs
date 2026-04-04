using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.ContactType)
                   .IsRequired();

            builder.Property(x => x.AdditionalInfo)
                   .HasMaxLength(500);

            builder.Property(x => x.Latitude)
                   .IsRequired();

            builder.Property(x => x.Longitude)
                   .IsRequired();

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(x => x.UpdatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasMany(x => x.ContactItems)
                   .WithOne(x => x.Contact)
                   .HasForeignKey(x => x.ContactId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
