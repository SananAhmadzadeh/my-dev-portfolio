using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class FaqConfiguration : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> builder)
        {
            builder.Property(f => f.Question)
                  .IsRequired()
                  .HasMaxLength(500);

            builder.Property(f => f.Answer)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(f => f.Order)
                   .IsRequired()
                   .HasDefaultValue(0);

            builder.Property(f => f.IsActive)
                   .HasDefaultValue(true);

            builder.Property(f => f.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(f => f.UpdatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
