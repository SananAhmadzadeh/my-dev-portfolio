using Business.Services.Abstract;
using Entities.DTOs.VideoDTOs;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Business.Services.Concrete
{
    public class VimeoManager : IVideoProviderService
    {
        private readonly HttpClient _httpClient;

        public VimeoManager(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var token = configuration["Vimeo:AccessToken"];
            if (string.IsNullOrEmpty(token))
                throw new Exception("Vimeo AccessToken is not configured.");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        public string ExtractVideoId(string url)
        {
            var regex = new Regex(@"vimeo\.com/(?:video/)?(\d+)");
            var match = regex.Match(url);

            if (!match.Success)
                throw new Exception("Invalid Vimeo URL");

            return match.Groups[1].Value;
        }

        public string GetEmbedUrl(string videoId)
        {
            if (string.IsNullOrEmpty(videoId))
                throw new ArgumentException("VideoId cannot be null or empty.");

            return $"https://player.vimeo.com/video/{videoId}";
        }

        public async Task<VideoMetaData?> GetVideoInfoAsync(string videoId)
        {
            if (string.IsNullOrEmpty(videoId))
                throw new ArgumentException("VideoId cannot be null or empty.");

            try
            {
                var response = await _httpClient.GetAsync($"https://api.vimeo.com/videos/{videoId}");
                if (!response.IsSuccessStatusCode)
                    return null;

                var content = await response.Content.ReadFromJsonAsync<JsonElement>();

                return new VideoMetaData
                {
                    VideoId = videoId,
                    Title = content.GetProperty("name").GetString(),
                    Description = content.GetProperty("description").GetString(),
                    Duration = TimeSpan.FromSeconds(content.GetProperty("duration").GetInt32()),
                    ThumbnailUrl = content.GetProperty("pictures")
                                          .GetProperty("sizes")[0]
                                          .GetProperty("link").GetString(),
                    EmbedUrl = GetEmbedUrl(videoId)
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching Vimeo video info: {ex.Message}");
                return null;
            }
        }
    }
}