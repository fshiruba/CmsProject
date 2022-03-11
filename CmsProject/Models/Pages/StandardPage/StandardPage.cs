using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace CmsProject.Models.Pages.StandardPage
{
    [ContentType(DisplayName = "Standard Page", GUID = "c0a25bb7-199c-457d-98c6-b0179c7acae8", Description = "Base skinny page for testing", GroupName = SystemTabNames.Content)]
    public class StandardPage : PageData
    {
        [Display(Name = "Main Body", GroupName = SystemTabNames.Content, Order = 200)]
        public virtual string MainBody { get; set; }

        [Display(Name = "Title", GroupName = SystemTabNames.Content, Order = 100)]
        public virtual string Title { get; set; }
    }
}