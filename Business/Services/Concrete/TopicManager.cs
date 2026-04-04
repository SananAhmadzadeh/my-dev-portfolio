using AutoMapper;
using Business.Services.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.TopicDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Concrete
{
    public class TopicManager : ITopicService
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public TopicManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddTopicAsync(CreateTopicDto createTopicDto)
        {
            var topic= _mapper.Map<Topic>(createTopicDto);
            await _unitOfWork.EfTopicRepository.AddAsync(topic);
            var result= await _unitOfWork.SaveAsync();
            if (result==0)
            {
                return new ErrorResult("movzu elave olunmadi");
            }
            return new SuccessResult("movzu ugurla elave olundu");
        }

        public async Task<IResult> DeleteTopicAsync(Guid id)
        {
            var topic =  await _unitOfWork.EfTopicRepository.GetAsync(t => t.Id == id);
            if (topic == null)
            {
                return new ErrorResult("Bu Id ilə mövzu tapılmadı");
            }
            _unitOfWork.EfTopicRepository.Delete(topic);
            return new SuccessResult("Mövzu uğurla silindi");
        }

        public async Task<IDataResult<List<GetAllTopicsDto>>> GetAllTopicsAsync()
        {
            var topic = await _unitOfWork.EfTopicRepository.GetAllAsync();
            if (topic.Count== 0)
            {
                return new ErrorDataResult<List<GetAllTopicsDto>>("Heç bir mövzu tapılmadı");
            }
                var mappedTopic = _mapper.Map<List<GetAllTopicsDto>>(topic);
                return new SuccessDataResult<List<GetAllTopicsDto>>(mappedTopic, "Mövzular uğurla tapıldı");
        }

        public async Task<IDataResult<GetTopicDto>> GetTopicById(Guid id)
        {
            var topic =await   _unitOfWork.EfTopicRepository.GetAsync(t => t.Id == id);
            if(topic == null)
            {
                return new ErrorDataResult<GetTopicDto>("Bu Id ilə mövzu tapılmadı");
            }
            var mappedTopic = _mapper.Map<GetTopicDto>(topic);
            return new SuccessDataResult<GetTopicDto>(mappedTopic, "Mövzu uğurla tapıldı");
        }

        public async Task<IResult> UpdateTopicAsync(Guid id, UpdateTopicDto TopicDto)
        {
            var topic =  await _unitOfWork.EfTopicRepository.GetAsync(t => t.Id == id);
            if (topic == null)
            {
                return new ErrorResult("Bu Id ilə mövzu tapılmadı");
            }
            var mappedTopic = _mapper.Map(TopicDto,topic);
            _unitOfWork.EfTopicRepository.Update(mappedTopic);
            var result = await _unitOfWork.SaveAsync();
            if (result == 0)
            {
                return new ErrorResult("Mövzu yenilənmədi");
            }
            return new SuccessResult("Mövzu uğurla yeniləndi");

        }
    }
}
