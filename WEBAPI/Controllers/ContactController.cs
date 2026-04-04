using Business.Services.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.DTOs.ContactDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IUserMessageService _userMessageService;
        public ContactController(IContactService contactService, IUserMessageService userMessageService)
        {
            _contactService = contactService;
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContactInfos()
        {
            var result = await _contactService.GetContactInfosAsync();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserMessage(UserMessageDTO userMessageDTO)
        {
            var result = await _userMessageService.CreateUserMessageAsync(userMessageDTO);
            if (!result.Success)
                return BadRequest(new ErrorResult("Message addition failed"));

            return Ok(result);
        }
    }
}
