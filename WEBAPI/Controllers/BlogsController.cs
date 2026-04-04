using Business.Services.Abstract;
using Entities.DTOs.BlogDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        readonly IBlogService _service;

        public BlogsController(IBlogService service)
        {
            _service = service;
        }

        //[AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var result = await _service.GetAllBlogsAsync();

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        //[AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetBlogById(Guid id)
        {
            var result = await _service.GetBlogByIdAsync(id);
            if (result.Success)
                return Ok(result);
            return NotFound(result);
        }

        //[Authorize(Roles = "Teacher")]
        //[HasPermission("BLOG.CREATE")]
        [HttpPost]
        public async Task<IActionResult> AddBlog([FromBody] CreateBlogDTO createBlogDTO)
        {
            var result = await _service.AddBlogAsync(createBlogDTO);
            if (result.Success)
                return Ok(result);
            return NotFound(result);
        }

        //[Authorize(Roles = "Student")]
        //[HasPermission("BLOG.DELETE")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBlog(Guid id)
        {
            var result = await _service.DeleteBlogAsync(id);
            if (result.Success)
                return NoContent();
            return NotFound(result);
        }

        //[Authorize(Roles = "Teacher")]
        //[HasPermission("BLOG.UPDATE")]
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(Guid id, UpdateBlogDTO updateBlogDTO)
        {
            var result = await _service.UpdateBlogAsync(id, updateBlogDTO);
            if (result.Success)
                return Ok(result);
            return NotFound(result);
        }
    }
}