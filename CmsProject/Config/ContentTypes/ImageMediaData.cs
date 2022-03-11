using System.Collections.Generic;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.Blobs;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Shell.ObjectEditing;

namespace CmsProject.Config.ContentTypes
{
    [ContentType(DisplayName = "Image File",
        GUID = "20644be7-3ca1-4f84-b893-ee021b73ce6c",
        Description = "Used for image file types such as jpg, jpeg, jpe, ico, gif, bmp, png")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageMediaData : ImageData
    {
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the generated thumbnail for this media.
        /// </summary>
        [ImageDescriptor(Width = 48, Height = 48)]
        public override Blob Thumbnail
        {
            get { return base.Thumbnail; }
            set { base.Thumbnail = value; }
        }
    }
}