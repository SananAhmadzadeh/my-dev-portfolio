using AutoMapper;
using Business.Services.Abstract;
using Core.Entities.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Concrete
{
    public class EventManager : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EventManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddEventAsync(CreateEventDto createEventDto)
        {
            var resultEvent = _mapper.Map<Event>(createEventDto);

            await _unitOfWork.EventRepository.AddAsync(resultEvent);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
            {
                return new ErrorResult("tədbir elavə olunmadı");
            }

            return new SuccessResult("tədbir elave edildi");
        }

        public async Task<IResult> DeleteEventAsync(Guid id)
        {
            var deleted = await _unitOfWork.EventRepository.GetAsync(e => e.Id == id);

            _unitOfWork.EventRepository.Delete(deleted);

            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
            {
                return new ErrorResult("tədbir silinmədi");
            }

            return new SuccessResult("tədbir silindi");
        }
        public async Task<IDataResult<List<GetAllEventDto>>> GetAllEventAsync()
        {
            var result = await _unitOfWork.EventRepository.GetAllAsync();
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<GetAllEventDto>>(_mapper.Map<List<GetAllEventDto>>(result), "tədbirlər gətirilmədi");
            }

            return new SuccessDataResult<List<GetAllEventDto>>(_mapper.Map<List<GetAllEventDto>>(result), "tədbirlər gətirildi");
        }

        public async Task<IDataResult<GetEventDto>> GetEventById(Guid id)
        {
            var result = await _unitOfWork.EventRepository.GetAsync(e => e.Id == id);

            if (result is null)
            {
                return new ErrorDataResult<GetEventDto>(_mapper.Map<GetEventDto>(result), "tədbir gətirilmədi");
            }

            return new SuccessDataResult<GetEventDto>(_mapper.Map<GetEventDto>(result), "tədbir gətirildi");
        }

        public async Task<IResult> UpdateEventAsync(UpdateEventDto dto, Guid id)
        {
            var existingEvent = await _unitOfWork.EventRepository.GetAsync(e => e.Id == id);
            if (existingEvent == null)
                return new ErrorResult("Event not found");

            if (dto.Title != null && dto.Title != existingEvent.Title)
                existingEvent.Title = dto.Title;

            if (!string.IsNullOrWhiteSpace(dto.Description) &&dto.Description != existingEvent.Description)
            {
                existingEvent.Description = dto.Description;
            }
            if (dto.IsFree.HasValue && dto.IsFree.Value != existingEvent.IsFree)
                existingEvent.IsFree = dto.IsFree.Value;

            if (dto.Date.HasValue && dto.Date.Value != existingEvent.Date)
                existingEvent.Date = dto.Date.Value;

            if (!string.IsNullOrWhiteSpace(dto.Time) && dto.Time != existingEvent.Time)
                existingEvent.Time = dto.Time;

            if (!string.IsNullOrWhiteSpace(dto.Location) && dto.Location != existingEvent.Location)
                existingEvent.Location = dto.Location;

            if (dto.Count.HasValue && dto.Count.Value != existingEvent.Count)
                existingEvent.Count = dto.Count.Value;

            existingEvent.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.EventRepository.Update(existingEvent);
            var saveResult = await _unitOfWork.SaveAsync();

            if (saveResult == 0)
                return new ErrorResult("tədbir dəyişdirilmədi");

            return new SuccessResult("Tədbir uğurla dəyişdirildi");
        }


    }
}
