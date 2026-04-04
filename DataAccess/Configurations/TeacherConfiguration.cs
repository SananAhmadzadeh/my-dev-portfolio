using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccess.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(x => x.Desc)
             .IsRequired()
             .HasMaxLength(100);

            builder.Property(x => x.Position)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.ImageUrl)
                .HasMaxLength(300);

            builder.HasOne(t => t.Course)
                .WithMany()
                .HasForeignKey(t => t.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.AppUser)
                .WithMany()
                .HasForeignKey(t => t.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t=> t.Blogs)
                .WithOne(b => b.Teacher)
                .HasForeignKey(b => b.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(x => x.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
