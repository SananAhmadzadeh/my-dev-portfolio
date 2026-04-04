using Core.Entities.Abstract;

namespace Entities.DTOs.LessonDTOs
{
    public class GetAllLessonDTO:IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CourseId { get; set; }
    }
}
