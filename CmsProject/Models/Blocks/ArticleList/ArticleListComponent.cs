using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EPiServer;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using SixLabors.ImageSharp;

namespace CmsProject.Models.Blocks.ArticleList
{
    [TemplateDescriptor]
    public partial class ArticleListComponent : AsyncBlockComponent<ArticleList>
    {
        protected override async Task<IViewComponentResult> InvokeComponentAsync(ArticleList currentContent)
        {
            ArticleList writtableClone = currentContent.CreateWritableClone() as ArticleList;

            if (writtableClone.ArticleListItems == null)
            {
                writtableClone.ArticleListItems = new List<ArticleListtItem>();
            }

            writtableClone.ArticleListItems = writtableClone.ArticleListItems.OrderBy(x => x.Order).ToList();

            return await Task.FromResult(View($"~/Models/Blocks/{nameof(ArticleList)}/{nameof(ArticleList)}.cshtml", new ArticleListViewModel(writtableClone)));
        }
    }
}