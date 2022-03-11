using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;

namespace CmsProject.Config.ContentTypes
{
    [ContentType(DisplayName = "Video File", GUID = "f2285e5a-be15-47b6-8952-e3c61deaefd2", Description = "Used for specific video file formats.")]
    [MediaDescriptor(ExtensionString = "flv,mp4,webm")]
    public class VideoMediaData : VideoData
    {
        /// <summary>
        /// Gets or sets the URL to the preview image.
        /// </summary>
        [UIHint(UIHint.Image)]
        public virtual ContentReference PreviewImage { get; set; }
    }
}