using Microsoft.AspNetCore.Mvc;
using EPiServer.Cms.Shell.ViewComposition;
using EPiServer.Web.Mvc;

namespace CmsProject.Models.Pages.StandardPage
{
    public class StandardPageController : PageController<StandardPage>
    {
        [HttpGet]
        public IActionResult Index(StandardPage currentPage)
        {
            return View(currentPage);
        }
    }
}