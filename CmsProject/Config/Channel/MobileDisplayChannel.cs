using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using EPiServer.Framework.Web;
using EPiServer.Web;
using Wangkanai.Detection.Services;

namespace CmsProject.Config.Channel
{
    public class MobileDisplayChannel : DisplayChannel
    {
        public override string ChannelName
        {
            get { return RenderingTags.Mobile; }
        }

        public override string DisplayName
        {
            get
            {
                return "Mobile";
            }
        }

        public override string ResolutionId
        {
            get
            {
                return typeof(MobileResolution).FullName;
            }
        }

        public override bool IsActive(HttpContext context)
        {
            //The sample code uses package 'Wangkanai.Detection' for device detection
            var detection = context.RequestServices.GetRequiredService<IDetectionService>();

            //return detection.Browser.Name != Wangkanai.Detection.Models.Browser.Firefox;

            return detection.Device.Type == Wangkanai.Detection.Models.Device.Mobile;
        }
    }
}