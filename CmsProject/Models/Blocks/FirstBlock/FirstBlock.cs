using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace CmsProject.Models.Blocks.FirstBlock
{
    [ContentType(DisplayName = "FirstBlock", GUID = "38d57768-e09e-4da9-90df-54c73c61b270", Description = "First Block")]
    public class FirstBlock : BlockData
    {
        [Display(Name = "Heading", Description = "Add a heading.", GroupName = SystemTabNames.Content, Order = 1)]
        public virtual string Heading { get; set; }

        [Display(Name = "MainIntro", Description = "Add a MainIntro.", GroupName = SystemTabNames.Content, Order = 2)]
        public virtual XhtmlString MainIntro { get; set; }
    }
}