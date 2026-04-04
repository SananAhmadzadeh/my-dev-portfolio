using Core.Entities.Abstract;
using Entities.Concrete;
//using Entities.DTOs.LessonDTOs;
//using Entities.TranslationDTOs.CourseTranslationDTOs;

namespace Entities.DTOs.CourseDTOs
{
    public class GetCourseDto : IDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; }
        public decimal Price { get; set; } = 0;
        public int Time { get; set; }
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
