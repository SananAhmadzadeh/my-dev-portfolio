//using Business.Services.Abstract;
//using Microsoft.AspNetCore.Mvc;

//namespace WEBAPI.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class HomePageController : Controller
//    {
//        private readonly IPopularCoursesService _popularCoursesService;
//        private readonly IFaqService _faqService;
//        private readonly IWhyChooseUsService _whyChooseUsService;

//        public HomePageController(IPopularCoursesService service, IFaqService faqService, IWhyChooseUsService whyChooseUsService)
//        {
//            _popularCoursesService = service;
//            _faqService = faqService;
//            _whyChooseUsService = whyChooseUsService;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetPopularCourses()
//        {
//            var result = await _popularCoursesService.GetPopularCoursesAsync();

//            if (!result.Success)
//                return BadRequest(result);

//            return Ok(result);
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetWhyChooseUs()
//        {
//            var result = await _whyChooseUsService.GetItemsAsync();

//            if (!result.Success)
//                return BadRequest(result);

//            return Ok(result);
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetFaq()
//        {
//            var result = await _faqService.GetFaqSectionAsync();

//            if (!result.Success)
//                return BadRequest(result);

//            return Ok(result);
//        }
//    }
//}
