using Core.Entities.Abstract;

namespace Entities.DTOs.LessonDTOs
{
    public class UpdateLessonDTO:IDto
    {
        public string Name { get; set; }
        public Guid CourseId { get; set; }
    }
}
