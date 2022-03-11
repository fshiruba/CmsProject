using Microsoft.AspNetCore.Mvc;
using EPiServer.Cms.Shell.ViewComposition;
using EPiServer.Web.Mvc;

namespace CmsProject.Models.Pages.SecondPage
{
    public class SecondPageController : PageController<SecondPage>
    {
        [HttpGet]
        public IActionResult Index(SecondPage currentPage)
        {
            return View(currentPage);
        }
    }
}