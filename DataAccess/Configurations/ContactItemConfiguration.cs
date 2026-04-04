using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ContactItemConfiguration : IEntityTypeConfiguration<ContactItem>
    {
        public void Configure(EntityTypeBuilder<ContactItem> builder)
        {
            builder.Property(x => x.ContactId)
                  .IsRequired();

            builder.Property(x => x.Item)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(x => x.UpdatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
