using Core.Utilities.Result.Abstract;
using Entities.DTOs.VideoDTOs;

namespace Business.Services.Abstract
{
    public interface IVideoService
    {
        public Task<IDataResult<List<GetAllVideoDto>>> GetAllVideosAsync();
        public Task<IDataResult<GetVideoDto>> GetVideoByIdAsync(Guid id);
        public Task<IResult> AddVideoAsync(CreateVideoDto createVideoDto);
        public Task<IResult> DeleteVideoAsync(Guid id);
        public Task<IResult> UpdateVideoAsync(Guid id, UpdateVideoDto updateVideoDto);
    }
}
