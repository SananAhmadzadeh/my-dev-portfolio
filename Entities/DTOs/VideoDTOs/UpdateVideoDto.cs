using Core.Entities.Abstract;

namespace Entities.DTOs.VideoDTOs
{
    public class UpdateVideoDto : IDto
    {
        public string Title { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
        public string? Description { get; set; }
        public Guid LessonId { get; set; }
        public int VideoOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
