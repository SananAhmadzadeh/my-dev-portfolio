using Core.Entities.Abstract;

namespace Entities.DTOs.TranslationDTOs.AboutTranslationDTOs
{
    public class CreateAboutTranslationDTO : IDto
    {
        public string LanguageCode { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
