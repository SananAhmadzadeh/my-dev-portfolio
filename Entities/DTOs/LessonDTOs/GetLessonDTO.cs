using Core.Entities.Abstract;

namespace Entities.DTOs.LessonDTOs
{
    public class GetLessonDTO:IDto
    {
        public string Name { get; set; }
    }
}
