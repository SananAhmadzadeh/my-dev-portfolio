using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class StatisticsConfiguration : IEntityTypeConfiguration<Statistics>
    {
        public void Configure(EntityTypeBuilder<Statistics> builder)
        {
            builder.ToTable("Statistics", t =>
            {
                t.HasCheckConstraint("CK_Statistics_GraduatedsCount", "\"GraduatedsCount\" >= 0");
                t.HasCheckConstraint("CK_Statistics_CoursesCount", "\"CoursesCount\" >= 0");
                t.HasCheckConstraint("CK_Statistics_GraduatesWorkingCount", "\"GraduatesWorkingCount\" >= 0");
                t.HasCheckConstraint("CK_Statistics_CompaniesPartnerCount", "\"CompaniesPartnerCount\" >= 0");
            });

            builder.Property(l => l.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(l => l.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
