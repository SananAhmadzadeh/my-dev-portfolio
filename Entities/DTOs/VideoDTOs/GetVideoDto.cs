using Core.Entities.Abstract;

namespace Entities.DTOs.VideoDTOs
{
    public class GetVideoDto : IDto
    {
        public string? Title { get; set; }
        public string? VideoUrl { get; set; }
        public string? VideoId { get; set; }
        public string? Description { get; set; }
        public string? ThumbnailUrl { get; set; }
        public TimeSpan Duration { get; set; }
        public int VideoOrder { get; set; }
        public bool IsActive { get; set; }
        public Guid LessonId { get; set; }
        public string LessonName { get; set; } = null!;
    }
}
