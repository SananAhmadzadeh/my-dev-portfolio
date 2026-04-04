using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.Property(v => v.Title)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(v => v.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.Location)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.EmploymentType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.WorkType)
                .IsRequired();

            builder.Property(v => v.SalaryMin)
                .HasPrecision(18, 2);

            builder.Property(v => v.SalaryMax)
                .HasPrecision(18, 2);

            builder.Property(v => v.Currency)
                .IsRequired()
                .HasMaxLength(10)
                .HasDefaultValue("AZN");

            builder.Property(v => v.IsNew)
                .HasDefaultValue(true);

            builder.Property(v => v.IsActive)
                .HasDefaultValue(true);

            builder.HasIndex(v => v.IsActive);
            builder.HasIndex(v => v.Category);

            builder.Property(v => v.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(v => v.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Vacancy_SalaryMin",
                    "\"SalaryMin\" >= 0"
                );

                t.HasCheckConstraint(
                    "CK_Vacancy_SalaryMax",
                    "\"SalaryMax\" >= 0"
                );

                t.HasCheckConstraint(
                    "CK_Vacancy_SalaryRange",
                    "\"SalaryMax\" >= \"SalaryMin\""
                );
            });
        }
    }
}
