using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class RecommendationConfiguration : IEntityTypeConfiguration<Recommendation>
    {
        public void Configure(EntityTypeBuilder<Recommendation> builder)
        {
            builder.Property(r => r.IconUrl)
                .IsRequired();

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(l => l.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(l => l.UpdatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
