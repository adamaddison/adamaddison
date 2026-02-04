using adamaddison.Interfaces;
using adamaddison.Models.Common;
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
                ViewData["TryCatchError"] = SiteConstants.PageLoadErrorMessage;

                return View();
            }
        }

        [HttpGet]
        [Route("Portfolio")]
        public async Task<IActionResult> Portfolio()
        {
            try
            {
                var vm = await _pageService.GetPortfolioContentAsync();

                return View(vm);
            }
            catch(Exception)
            {
                ViewData["TryCatchError"] = SiteConstants.PageLoadErrorMessage;

                return View();
            }
        }

        [HttpGet]
        [Route("WorkAndEducation")]
        public async Task<IActionResult> WorkAndEducation()
        {
            try
            {
                var vm = await _pageService.GetWorkAndEducationContentAsync();

                return View(vm);
            }
            catch(Exception)
            {
                ViewData["TryCatchError"] = SiteConstants.PageLoadErrorMessage;

                return View();
            }
        }

        [HttpGet]
        [Route("Experience")]
        public async Task<IActionResult> Experience()
        {
            try
            {
                var vm = await _pageService.GetExperienceContentAsync();

                return View(vm);
            }
            catch(Exception)
            {
                ViewData["TryCatchError"] = SiteConstants.PageLoadErrorMessage;

                return View();
            }
        }

        [HttpGet]
        [Route("About")]
        public async Task<IActionResult> About()
        {
            try
            {
                var vm = await _pageService.GetAboutContentAsync();

                return View(vm);
            }
            catch(Exception)
            {
                ViewData["TryCatchError"] = SiteConstants.PageLoadErrorMessage;

                return View();
            }
        }
    }
}
