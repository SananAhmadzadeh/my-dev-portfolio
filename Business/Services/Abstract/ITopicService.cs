using Core.Utilities.Result.Abstract;
using Entities.DTOs.GroupDTOs;
using Entities.DTOs.TopicDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstract
{
    public interface ITopicService
    {
        public Task<IDataResult<List<GetAllTopicsDto>>> GetAllTopicsAsync();

        public Task<IDataResult<GetTopicDto>> GetTopicById(Guid id);

        public Task<IResult> AddTopicAsync(CreateTopicDto createTopicDto);

        public Task<IResult> DeleteTopicAsync(Guid id);

        public Task<IResult> UpdateTopicAsync(Guid id, UpdateTopicDto TopicDto);
    }
}
