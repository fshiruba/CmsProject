using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;
using CmsProject.Models.BaseTypes;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.PlugIn;
using EPiServer.Shell.ObjectEditing;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace CmsProject.Models.Blocks.FrontCover
{
    [ContentType(DisplayName = "Front Cover", GUID = "556b392a-d48b-4dec-9491-a380809489fe", Description = "Seeds Front Cover Block")]
    public class FrontCover : BlockData
    {
        [Display(Name = "Background Image", Description = "A big image to use in the background", GroupName = SystemTabNames.Content, Order = 40)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference BackgroundImage { get; set; }

        [Display(Name = "Logo", Description = "Logo to be displayed at the top-left corner", GroupName = SystemTabNames.Content, Order = 10)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Logo { get; set; }

        [Display(Name = "Main Text", Description = "Html to display in front of the background picture", GroupName = SystemTabNames.Content, Order = 50)]
        public virtual XhtmlString MainText { get; set; }

        [Display(Name = "MainText Color", Description = "Color in hex format (tries to parse color by name if possible)", GroupName = SystemTabNames.Content, Order = 49)]
        [ClientEditor(ClientEditingClass = "shiruba/ColorPicker")]
        public virtual string MainTextColor
        {
            get { return this.GetPropertyValue(page => page.MainTextColor) ?? "#000000FF"; }
            set { this.SetPropertyValue(page => page.MainTextColor, value); }
        }

        [JsonIgnore]
        [EditorDescriptor(EditorDescriptorType = typeof(EnhancedCollectionEditorDescriptor<NavLink>))]
        [Display(Name = "Navigation Links", Description = "Up to 9 Links supported", GroupName = SystemTabNames.Content, Order = 100)]
        [MaxLength(10, ErrorMessage = "Only up to 10 links allowed")]
        public virtual IList<NavLink> Navlinks { get; set; }

        [Display(Name = "Navigation Links Color", Description = "Color in hex format (tries to parse color by name if possible)", GroupName = SystemTabNames.Content, Order = 99)]
        [ClientEditor(ClientEditingClass = "shiruba/ColorPicker")]
        public virtual string NavLinkTextColor
        {
            get { return this.GetPropertyValue(page => page.NavLinkTextColor) ?? "#000000FF"; }
            set { this.SetPropertyValue(page => page.NavLinkTextColor, value); }
        }

        [Display(Name = "Scroll Button", Description = "The image to show in the 'scroll down' button", GroupName = SystemTabNames.Content, Order = 60)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference ScrollButtonPicture { get; set; }
    }

    public class NavLink
    {
        [Display(Name = "Column Size Override", Description = "Will override the column size if set to greater than 0", GroupName = SystemTabNames.Content, Order = 30)]
        [Range(0, 10, ErrorMessage = "Column Size Override must be into the 0-10 range")]
        [SelectOne(SelectionFactoryType = typeof(FromRangeSelectionFactory))]
        [DefaultValue(0)]
        public virtual int ColumnSizeOverride { get; set; }

        [Display(Name = "Label", Description = "The actual text displayed on the front cover", GroupName = SystemTabNames.Content, Order = 10)]
        public virtual string Label { get; set; }

        [Display(Name = "Link", Description = "Clicking on the label will lead to this target", GroupName = SystemTabNames.Content, Order = 20)]
        [MaxLength(1, ErrorMessage = "Only one link per Label")]
        public virtual LinkItemCollection Link { get; set; }
    }

    [PropertyDefinitionTypePlugIn]
    public class NavLinkProperty : PropertyList<NavLink>
    {
        protected override NavLink ParseItem(string value)
        {
            Debug.WriteLine(value);
            return System.Text.Json.JsonSerializer.Deserialize<NavLink>(value);   //JsonConvert.DeserializeObject<GroupLinkCollection>(value);
        }
    }
}