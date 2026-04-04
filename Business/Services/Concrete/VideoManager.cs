using AutoMapper;
using Business.Factories.Abstract;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.VideoDTOs;

namespace Business.Services.Concrete
{
    public class VideoManager : IVideoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IVideoProviderFactory _factory;
     

        public VideoManager(IUnitOfWork unitOfWork, IMapper mapper, IVideoProviderFactory factory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _factory = factory;
        }

        public async Task<IResult> AddVideoAsync(CreateVideoDto dto)
        {
            var providerService = _factory.Get(dto.Provider);
            var videoId = providerService.ExtractVideoId(dto.VideoUrl);

            var videoInfo = await providerService.GetVideoInfoAsync(videoId);

            if (videoInfo == null)
                return new ErrorResult("Video not found in provider.");

            var video = new Video
            {
                Title = dto.Title,
                VideoId = videoId,
                Provider = dto.Provider,
                Description = dto.Description,
                Duration = videoInfo.Duration,
                ThumbnailUrl = videoInfo.ThumbnailUrl,
                LessonId = dto.LessonId,
                VideoOrder = dto.VideoOrder,
                IsActive = true
            };

            await _unitOfWork.VideoRepository.AddAsync(video);
            await _unitOfWork.SaveAsync();

            return new SuccessResult("Video added successfully.");
        }

        public async Task<IResult> DeleteVideoAsync(Guid id)
        {
            var video = await _unitOfWork.VideoRepository.GetAsync(v => v.Id == id);
            if (video == null)
                return new ErrorResult("Video not found");

            if (!string.IsNullOrEmpty(video.VideoId))
            {
                var providerService = _factory.Get(video.Provider);
            }

            video.IsDeleted = true;
            _unitOfWork.VideoRepository.Update(video);
            await _unitOfWork.SaveAsync();

            return new SuccessResult("Video deleted successfully");
        }

        public async Task<IDataResult<List<GetAllVideoDto>>> GetAllVideosAsync()
        {
            var videos = await _unitOfWork.VideoRepository.GetAllAsync(
                filter: v => !v.IsDeleted,
                incudes: "Lesson"
            );

            var dtos = _mapper.Map<List<GetAllVideoDto>>(videos);

            foreach (var dto in dtos)
            {
                var video = videos.First(v => v.Id == dto.Id);

                var providerService = _factory.Get(video.Provider);

                dto.VideoUrl = providerService.GetEmbedUrl(video.VideoId);
                dto.VideoId = video.VideoId;
            }

            return new SuccessDataResult<List<GetAllVideoDto>>(dtos);
        }

        public async Task<IDataResult<GetVideoDto>> GetVideoByIdAsync(Guid id)
        {
            var video = await _unitOfWork.VideoRepository.GetAsync(
                filter: v => v.Id == id && !v.IsDeleted,
                incudes: "Lesson"
            );

            if (video == null)
                return new ErrorDataResult<GetVideoDto>("Video not found");

            var dto = _mapper.Map<GetVideoDto>(video);

            var providerService = _factory.Get(video.Provider);

            dto.VideoUrl = providerService.GetEmbedUrl(video.VideoId);
            dto.VideoId = video.VideoId;

            return new SuccessDataResult<GetVideoDto>(dto);
        }

        public async Task<IResult> UpdateVideoAsync(Guid id, UpdateVideoDto updateVideoDto)
        {
            var video = await _unitOfWork.VideoRepository.GetAsync(v => v.Id == id);
            if (video == null)
                return new ErrorResult("Video not found");

            var providerService = _factory.Get(video.Provider);
            // await providerService.UpdateVideoAsync(video.VideoId, updateVideoDto.Title, updateVideoDto.Description);

            _mapper.Map(updateVideoDto, video);
            _unitOfWork.VideoRepository.Update(video);
            await _unitOfWork.SaveAsync();

            return new SuccessResult("Video updated successfully");
        }
    }
}
