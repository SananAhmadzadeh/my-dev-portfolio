using Entities.DTOs.VideoDTOs;

namespace Business.Services.Abstract
{
    public interface IVideoProviderService
    {
        string ExtractVideoId(string url);
        Task<VideoMetaData?> GetVideoInfoAsync(string videoId);
        string GetEmbedUrl(string videoId);
    }
}
