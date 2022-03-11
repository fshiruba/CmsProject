using Microsoft.AspNetCore.Mvc;
using CmsProject.Models.BaseTypes;
using EPiServer.Cms.Shell.ViewComposition;
using EPiServer.Web.Mvc;

namespace CmsProject.Models.Pages.SeedsMockupPage
{
    public class SeedsMockupPageController : PageController<SeedsMockupPage>
    {
        [HttpGet]
        public IActionResult Index(SeedsMockupPage currentPage)
        {
            return View(new BaseViewModel<SeedsMockupPage>(currentPage));
        }
    }
}