using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(100);

        builder.Property(x => x.Description)
                   .IsRequired()
                   .HasMaxLength(500);

        builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(x => x.UpdatedAt)
               .HasDefaultValueSql("CURRENT_TIMESTAMP");

        //builder.Property(x => x.DefaultLanguageCode)
        //       .IsRequired()
        //       .HasMaxLength(5);

        //builder.HasMany(x => x.Translations)
        //       .WithOne(x => x.Blog)
        //       .HasForeignKey(x => x.BlogId)
        //       .OnDelete(DeleteBehavior.Cascade);
    }
}
