using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Description)
                       .IsRequired()
                       .HasMaxLength(500);

            builder.Property(c => c.Price)
                   .HasColumnType("numeric(18,2)");

            builder.Property(c => c.Time)
                    .IsRequired();

            builder.Property(c => c.ImageUrl)
                   .HasMaxLength(200);

            builder.Property(c => c.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.UpdatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            //builder.Property(x => x.DefaultLanguageCode)
            //       .IsRequired()
            //       .HasMaxLength(5);

            //builder.HasMany(c => c.Lessons)
            //       .WithOne(l => l.Course)
            //       .HasForeignKey(l => l.CourseId)
            //       .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(x => x.Translations)
            //       .WithOne(x => x.Course)
            //       .HasForeignKey(x => x.CourseId)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
