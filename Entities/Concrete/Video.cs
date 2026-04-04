using Core.Entities.Abstract;
using Entities.Common;
using Entities.Enums.Video;

namespace Entities.Concrete
{
    public class Video : BaseEntity, IEntity
    {
        public string? Title { get; set; }
        public string VideoId { get; set; } = null!;
        public VideoProvider Provider { get; set; }
        public string? Description { get; set; }
        public TimeSpan Duration { get; set; }
        public string? ThumbnailUrl { get; set; }
        public int VideoOrder { get; set; }
        public bool IsActive { get; set; }
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}
