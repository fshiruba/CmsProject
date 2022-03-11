using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CmsProject.Models.BaseTypes;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace CmsProject.Models.Pages.SeedsMockupPage
{
    [ContentType(DisplayName = "Seeds Mockup Page", GUID = "1e6f0c1e-4537-42c6-a6f5-95bf3412ad4a", Description = "Seeds page with placeholders", GroupName = SystemTabNames.Content)]
    public class SeedsMockupPage : BasePage
    {
        [Display(Name = "Content Area", GroupName = SystemTabNames.Content, Order = 200)]
        public virtual ContentArea ContentArea { get; set; }
    }
}