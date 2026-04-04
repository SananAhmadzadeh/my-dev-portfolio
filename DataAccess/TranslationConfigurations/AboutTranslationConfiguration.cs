//using Entities.TranslationConcrete;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace DataAccess.TranslationConfigurations
//{
//    public class AboutTranslationConfiguration : IEntityTypeConfiguration<AboutTranslation>
//    {
//        public void Configure(EntityTypeBuilder<AboutTranslation> builder)
//        {
//            builder.Property(x => x.Title)
//                  .IsRequired()
//                  .HasMaxLength(200);

//            builder.Property(x => x.Description)
//                   .IsRequired();

//            builder.Property(x => x.LanguageCode)
//                   .IsRequired()
//                   .HasMaxLength(5);

//            builder.Property(x => x.Slug)
//                   .IsRequired()
//                   .HasMaxLength(300);

//            builder.HasIndex(x => new { x.AboutId, x.LanguageCode }).IsUnique();
//            builder.HasIndex(x => x.Slug).IsUnique();
//        }
//    }
//}
