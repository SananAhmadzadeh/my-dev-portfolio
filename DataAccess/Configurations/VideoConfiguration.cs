using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.Property(v => v.VideoId).HasMaxLength(50).IsRequired();

            builder.HasIndex(v => v.VideoId)
                   .IsUnique();

            builder.Property(v => v.Title)
                .HasMaxLength(200);

            builder.Property(v => v.Description)
                .HasMaxLength(1000);

            builder.Property(v => v.ThumbnailUrl)
                .HasMaxLength(500);

            builder.Property(v => v.VideoOrder)
                .IsRequired();

            builder.Property(v => v.Duration)
                .HasColumnType("interval")
                .IsRequired();

            builder.Property(v => v.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(v => v.IsActive)
                .HasDefaultValue(true);

            builder.HasOne(v => v.Lesson)
                .WithMany(l => l.Videos)
                .HasForeignKey(v => v.LessonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(v => v.LessonId);

            builder.HasQueryFilter(v => !v.IsDeleted);

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(x => x.UpdatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.ToTable(video =>
            {
                video.HasCheckConstraint("CK_Video_VideoOrder_NonNegative", "\"VideoOrder\" >= 1");
            });
        }
    }
}
