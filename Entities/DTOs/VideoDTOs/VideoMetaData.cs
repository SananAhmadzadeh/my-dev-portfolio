namespace Entities.DTOs.VideoDTOs
{
    public class VideoMetaData
    {
        public string VideoId { get; set; } = null!;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public TimeSpan Duration { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? EmbedUrl { get; set; }
    }
}
