using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class GraduateReviewConfiguration : IEntityTypeConfiguration<GraduateReview>
    {
        public void Configure(EntityTypeBuilder<GraduateReview> builder)
        {
            builder.ToTable("GraduateReviews");

            builder.HasKey(gr => gr.Id);

            builder.Property(gr => gr.Comment)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(gr => gr.Rating)
                   .IsRequired()
                   .HasColumnType("numeric(3,2)"); 

            builder.Property(gr => gr.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(gr => gr.UpdatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(gr => gr.Graduate)
                   .WithMany() 
                   .HasForeignKey(gr => gr.GraduateId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
