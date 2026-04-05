using Core.Entities.Abstract;

namespace Entities.DTOs.TranslationDTOs.AboutTranslationDTOs
{
    public class UpdateAboutTranslationDTO : IDto
    {
        public string LanguageCode { get; set; } = null!;
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
