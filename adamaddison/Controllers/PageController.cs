using adamaddison.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace adamaddison.Controllers
{
    [Route("")]
    public class PageController : Controller
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [HttpGet]
        [Route("")]
        [Route("Home")]
        public async Task<IActionResult> Home()
        {
            try
            {
                var vm = await _pageService.GetHomeContentAsync();

                return View(vm); 
            }
            catch(Exception)
            {
                ViewData["TryCatchError"] = "Something went wrong. Please try again later.";

                return View();
            }
            
        }

        [HttpGet]
        [Route("Portfolio")]
        public async Task<IActionResult> Portfolio()
        {
            var vm = await _pageService.GetPortfolioContentAsync();

            return View(vm);
        }

        [HttpGet]
        [Route("WorkAndEducation")]
        public async Task<IActionResult> WorkAndEducation()
        {
            var vm = await _pageService.GetWorkAndEducationContentAsync();

            return View(vm);
        }

        [HttpGet]
        [Route("Experience")]
        public async Task<IActionResult> Experience()
        {
            var vm = await _pageService.GetExperienceContentAsync();

            return View(vm);
        }

        [HttpGet]
        [Route("About")]
        public async Task<IActionResult> About()
        {
            var vm = await _pageService.GetAboutContentAsync();

            return View(vm);
        }
    }
}
