using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;
using CmsProject.Models.BaseTypes;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.PlugIn;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace CmsProject.Models.Blocks.ArticleList
{
    [ContentType(DisplayName = "Article List", GUID = "20b321c1-60e2-4591-b6c0-bd7e855e0493", Description = "Article List Block")]
    public class ArticleList : BlockData
    {
        [JsonIgnore]
        [EditorDescriptor(EditorDescriptorType = typeof(EnhancedCollectionEditorDescriptor<ArticleListtItem>))]
        [Display(Name = "Article List Items", Description = "Alternating blocks with images and text", GroupName = SystemTabNames.Content, Order = 20)]
        public virtual IList<ArticleListtItem> ArticleListItems { get; set; }

        [Display(Name = "Article List Text Area", Description = "HTML block before the articles", GroupName = SystemTabNames.Content, Order = 10)]
        public virtual XhtmlString IntroText { get; set; }
    }

    [PropertyDefinitionTypePlugIn]
    public class ArticleListItemProperty : PropertyList<ArticleListtItem>
    {
        protected override ArticleListtItem ParseItem(string value)
        {
            return System.Text.Json.JsonSerializer.Deserialize<ArticleListtItem>(value);
        }
    }

    public class ArticleListtItem
    {
        [Display(Name = "Article Image", Description = "Prefer medium size image", GroupName = SystemTabNames.Content, Order = 10)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference ArticleImage { get; set; }

        [Display(Name = "Link", Description = "Clicking on the image will lead to this link", GroupName = SystemTabNames.Content, Order = 20)]
        [MaxLength(1, ErrorMessage = "Only one link per Label")]
        public virtual LinkItemCollection Link { get; set; }

        [Display(Name = "Order", Description = "Manually set the article display order", GroupName = SystemTabNames.Content, Order = 40)]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public virtual int Order { get; set; }

        [Display(Name = "Text", Description = "Text displayed below the image", GroupName = SystemTabNames.Content, Order = 30)]
        public virtual XhtmlString Text { get; set; }
    }
}