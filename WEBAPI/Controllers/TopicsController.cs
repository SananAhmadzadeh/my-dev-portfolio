using Business.Services.Abstract;
using Entities.DTOs.TopicDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _topicService;
        public TopicsController(ITopicService topicService)
        {
            _topicService = topicService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTopics()
        {
            var result = await _topicService.GetAllTopicsAsync();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetTopicById(Guid id)
        {
            var result = await _topicService.GetTopicById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddTopic(CreateTopicDto createTopicDto)
        {
            var result = await _topicService.AddTopicAsync(createTopicDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTopic(Guid id)
        {
            var result = await _topicService.DeleteTopicAsync(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTopic(Guid id, UpdateTopicDto updateTopicDto)
        {
            var result = await _topicService.UpdateTopicAsync(id, updateTopicDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}