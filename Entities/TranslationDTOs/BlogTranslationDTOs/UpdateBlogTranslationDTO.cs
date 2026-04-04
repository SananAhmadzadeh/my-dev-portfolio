using Core.Entities.Abstract;

namespace Entities.TranslationDTOs.BlogTranslationDTOs
{
    public class UpdateBlogTranslationDTO : IDto
    {
        public string LanguageCode { get; set; } = null!;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Slug { get; set; }
    }
}
