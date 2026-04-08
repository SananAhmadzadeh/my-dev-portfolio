using Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "SuperAdmin")]

    public class AppLogsController : ControllerBase
    {
        private readonly IAppLogService _appLogService;

        public AppLogsController(IAppLogService appLogService)
        {
            _appLogService = appLogService;
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAppLogs()
        {
            var result = await _appLogService.GetAllAppLogsAsync();

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

    }
}
