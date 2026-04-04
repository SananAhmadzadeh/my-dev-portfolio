using Core.Entities.Abstract;

namespace Entities.DTOs.LessonDTOs
{
    public class CreateLessonDTO:IDto
    {
        public string Name { get; set; }
        public Guid CourseId { get; set; }
    }
}
