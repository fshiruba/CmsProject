using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web.Mvc;

namespace CmsProject.Models.Blocks.FirstBlock
{
    [TemplateDescriptor(Tags = new string[] { RenderingTags.Mobile })]
    public partial class FirstBlockMobileComponent : AsyncBlockComponent<FirstBlock>
    {
        protected override async Task<IViewComponentResult> InvokeComponentAsync(FirstBlock currentContent)
        {
            return await Task.FromResult(View($"~/Models/Blocks/{nameof(FirstBlock)}/{nameof(FirstBlock)}.cshtml", currentContent));
        }
    }
}