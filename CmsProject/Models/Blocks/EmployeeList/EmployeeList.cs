using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using CmsProject.Models.BaseTypes;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.PlugIn;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace CmsProject.Models.Blocks.EmployeeList
{
    [ContentType(DisplayName = "Employee List", GUID = "15a748a2-78da-4ecf-b93c-85bb9f609943", Description = "Employee List Block")]
    public class EmployeeList : BlockData
    {
        [JsonIgnore]
        [EditorDescriptor(EditorDescriptorType = typeof(EnhancedCollectionEditorDescriptor<EmployeeListItem>))]
        [Display(Name = "Employee list Items", Description = "Side-by-side blocks with images and text", GroupName = SystemTabNames.Content, Order = 30)]
        public virtual IList<EmployeeListItem> EmployeeListItems { get; set; }

        [Display(Name = "Employee List text area", Description = "First big text before the list", GroupName = SystemTabNames.Content, Order = 10)]
        public virtual XhtmlString IntroText { get; set; }

        [Display(Name = "Number of Columns", Description = "How many columns?", GroupName = SystemTabNames.Content, Order = 20)]
        [Range(0, 10, ErrorMessage = "Number of columns must be into the 0-10 range")]
        [SelectOne(SelectionFactoryType = typeof(FromRangeSelectionFactory))]
        [DefaultValue(4)]
        public virtual int NumColumns { get; set; }
    }

    public class EmployeeListItem
    {
        [Display(Name = "Employee Image", Description = "Prefer 'portrait' images", GroupName = SystemTabNames.Content, Order = 10)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference ArticleImage { get; set; }

        [Display(Name = "Order", Description = "Manually set the employee display order", GroupName = SystemTabNames.Content, Order = 40)]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public virtual int Order { get; set; } = 0;

        [Display(Name = "Text", Description = "Text displayed below the image", GroupName = SystemTabNames.Content, Order = 30)]
        public virtual XhtmlString Text { get; set; }
    }

    [PropertyDefinitionTypePlugIn]
    public class EmployeeViewItemProperty : PropertyList<EmployeeListItem>
    {
        protected override EmployeeListItem ParseItem(string value)
        {
            Debug.WriteLine(value);
            return System.Text.Json.JsonSerializer.Deserialize<EmployeeListItem>(value);
        }
    }
}