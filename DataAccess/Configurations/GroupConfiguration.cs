using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(g => g.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasOne(g => g.Teacher)
                .WithMany()
                .HasForeignKey(g => g.TeacherId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(g => g.Course)
                .WithMany()
                .HasForeignKey(g => g.CourseId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Group_Name_Length",
                    "LENGTH(\"Name\") >= 3 AND LENGTH(\"Name\") <= 100"
                );
            });
        }
    }
}
