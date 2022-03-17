using System.Collections.Generic;
using System.Linq;
using CmsProject.Models.BaseTypes;
using MoreLinq;

namespace CmsProject.Models.Blocks.ArticleList
{
    public class ArticleListViewModel : BlockViewModel<ArticleList>
    {
        public ArticleListViewModel(ArticleList incomingPage) : base(incomingPage)
        {
        }
    }
}