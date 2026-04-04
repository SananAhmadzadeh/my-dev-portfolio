//using Entities.TranslationConcrete;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace DataAccess.TranslationConfigurations
//{
//    public class CourseTranslationConfiguration : IEntityTypeConfiguration<CourseTranslation>
//    {
//        public void Configure(EntityTypeBuilder<CourseTranslation> builder)
//        {
//            builder.Property(x => x.Name)
//                    .IsRequired()
//                    .HasMaxLength(200);

//            builder.Property(x => x.Description)
//                   .IsRequired();

//            builder.Property(x => x.LanguageCode)
//                   .IsRequired()
//                   .HasMaxLength(5);

//            builder.Property(x => x.Slug)
//                   .HasMaxLength(300);

//            builder.HasIndex(x => new { x.CourseId, x.LanguageCode })
//                   .IsUnique();

//            // SEO üçün slug unique ola bilər
//            builder.HasIndex(x => new { x.LanguageCode, x.Slug })
//                   .IsUnique()
//                   .HasFilter("\"Slug\" IS NOT NULL");
//        }
//    }
//}
