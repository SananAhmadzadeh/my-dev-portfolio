using Core.Entities.Abstract;

namespace Entities.TranslationDTOs.BlogTranslationDTOs
{
    public class GetBlogTranslationDTO : IDto
    {
        public string LanguageCode { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Slug { get; set; }
    }
}
