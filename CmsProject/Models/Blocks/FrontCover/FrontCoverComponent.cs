using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EPiServer;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using SixLabors.ImageSharp;

namespace CmsProject.Models.Blocks.FrontCover
{
    [TemplateDescriptor]
    public partial class FrontCoverComponent : AsyncBlockComponent<FrontCover>
    {
        protected override async Task<IViewComponentResult> InvokeComponentAsync(FrontCover currentContent)
        {
            //Check colors, cache properties to avoid calling the delegate
            var navLinkColorRaw = currentContent.NavLinkTextColor;
            var mainTextColorRaw = currentContent.MainTextColor;

            var writable = currentContent.CreateWritableClone() as FrontCover;

            //navlink color
            writable.NavLinkTextColor = Color.TryParseHex(navLinkColorRaw, out Color navLinkColorHex)
                ? $"#{navLinkColorHex.ToHex()}"
                : Color.TryParse(navLinkColorRaw, out Color navLinkColorName)
                    ? $"#{navLinkColorName.ToHex()}"
                    : $"#{Color.Black.ToHex()}";

            //main text color
            writable.MainTextColor = Color.TryParseHex(mainTextColorRaw, out Color mainTextColorHex)
                ? $"#{mainTextColorHex.ToHex()}"
                : Color.TryParse(mainTextColorRaw, out Color mainTextColorName) ? $"#{mainTextColorName.ToHex()}" : $"#{Color.Black.ToHex()}";

            return await Task.FromResult(View($"~/Models/Blocks/{nameof(FrontCover)}/{nameof(FrontCover)}.cshtml", currentContent));
        }
    }
}