using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Title)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(e => e.Location)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(e => e.Count)
                   .HasDefaultValue(0);

            builder.Property(e => e.IsFree)
                   .HasDefaultValue(true);

            builder.Property(e => e.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.UpdatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

    }
}
