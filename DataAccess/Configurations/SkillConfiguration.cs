using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasIndex(s => s.Name)
                .IsUnique();

            builder.Property(l => l.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(l => l.UpdatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

    }
}
