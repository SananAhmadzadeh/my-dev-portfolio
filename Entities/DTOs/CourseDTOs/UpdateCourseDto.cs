//using Entities.TranslationDTOs.CourseTranslationDTOs;


namespace Entities.DTOs.CourseDTOs
{
    public class UpdateCourseDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; } = 0;
        public int Time { get; set; }
        //public List<UpdateCourseTranslationDTO>? Translations { get; set; }
    }
}
