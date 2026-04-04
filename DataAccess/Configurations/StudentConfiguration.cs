using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(x => x.Address)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(x => x.DateOfBirth)
            .HasColumnType("date")
            .IsRequired();

        builder.HasOne(s => s.Group)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.AppUser)
            .WithMany()
            .HasForeignKey(s => s.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(s =>
        {
            s.HasCheckConstraint(
                "CK_Student_Address",
                "LENGTH(\"Address\") >= 1 AND LENGTH(\"Address\") <= 250"
            );

            s.HasCheckConstraint(
                "CK_Student_Certificate",
                "(\"IsCertificate\" = false AND \"CertificateUrl\" IS NULL) OR " +
                "(\"IsCertificate\" = true AND \"CertificateUrl\" IS NOT NULL)"
            );
        });
    }
}