using Microsoft.AspNetCore.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web.Mvc;

namespace CmsProject.Models.Pages.SecondPage
{
    [TemplateDescriptor(Tags = new string[] { RenderingTags.Mobile })]
    public class SecondPageMobileController : PageController<SecondPage>
    {
        [HttpGet]
        public IActionResult Index(SecondPage currentPage)
        {
            return View(currentPage);
        }
    }
}