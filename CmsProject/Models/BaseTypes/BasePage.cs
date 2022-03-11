using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;

namespace CmsProject.Models.BaseTypes
{
    public class BasePage : PageData, IBasePage
    {
        private string title;

        [Display(Name = "Title", GroupName = SystemTabNames.Content, Order = 100)]
        public virtual string Title
        { get { return title ?? $"{Name} {ContentGuid}"; } set => title = value; }
    }
}