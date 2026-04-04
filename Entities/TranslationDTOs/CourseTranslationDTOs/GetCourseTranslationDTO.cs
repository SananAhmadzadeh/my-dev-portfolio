using Core.Entities.Abstract;

namespace Entities.TranslationDTOs.CourseTranslationDTOs
{
    public class GetCourseTranslationDTO : IDto
    {
        public string LanguageCode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Slug { get; set; }
    }
}
