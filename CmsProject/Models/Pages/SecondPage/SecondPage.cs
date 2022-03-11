using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace CmsProject.Models.Pages.SecondPage
{
    [ContentType(DisplayName = "Second Page", GUID = "82267687-3eea-402c-ab88-487972396e91", Description = "Base skinny page for testing", GroupName = SystemTabNames.Content)]
    public class SecondPage : PageData
    {
        [Display(Name = "Main Body", GroupName = SystemTabNames.Content, Order = 200)]
        public virtual XhtmlString MainBody { get; set; }

        [Display(Name = "Main content area", GroupName = SystemTabNames.Content, Order = 200)]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(Name = "Title", GroupName = SystemTabNames.Content, Order = 100)]
        public virtual string Title { get; set; }
    }
}