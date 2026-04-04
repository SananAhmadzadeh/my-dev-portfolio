using Core.Utilities.Result.Abstract;
using Entities.DTOs.Events;

namespace Business.Services.Abstract
{
    public interface IEventService
    {
        public Task<IDataResult<List<GetAllEventDto>>> GetAllEventAsync();

        public Task<IDataResult<GetEventDto>> GetEventById(Guid id);

        public Task<IResult> AddEventAsync(CreateEventDto createEventDto);

        public Task<IResult> DeleteEventAsync(Guid id);

        public Task<IResult> UpdateEventAsync(UpdateEventDto dto,Guid id);
    }
}
