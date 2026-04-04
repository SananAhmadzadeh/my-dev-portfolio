using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class GraduateConfiguration : IEntityTypeConfiguration<Graduate>
    {
        public void Configure(EntityTypeBuilder<Graduate> builder)
        {
            builder.Property(g => g.FullName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(g => g.UserName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(g => g.Password)
                   .IsRequired()
                   .HasMaxLength(100); 

            builder.Property(g => g.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(g => g.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(g => g.Address)
                   .HasMaxLength(200);

            builder.Property(g => g.DateOfBirth)
                   .IsRequired();

            builder.Property(g => g.IsCertificate)
                   .HasDefaultValue(false);

            builder.Property(g => g.CertificateUrl)
                   .HasMaxLength(200)
                   .IsRequired(false);

            builder.Property(g => g.GroupId)
                   .IsRequired();

            builder.Property(g => g.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(g => g.UpdatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
