using Core.Entities.Abstract;
using Entities.Enums.Video;

namespace Entities.DTOs.VideoDTOs
{
    public class CreateVideoDto : IDto  
    {
        public string Title { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
        public string? Description { get; set; }
        public Guid LessonId { get; set; }
        public int VideoOrder { get; set; }
        public VideoProvider Provider { get; set; }
    }
}
