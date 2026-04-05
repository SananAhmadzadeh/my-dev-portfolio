using Core.Entities.Abstract;

namespace Entities.DTOs.TranslationDTOs.BlogTranslationDTOs
{
    public class CreateBlogTranslationDTO : IDto
    {
        public string LanguageCode { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
