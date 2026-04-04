using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(l => l.Name)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(l => l.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(l => l.UpdatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
