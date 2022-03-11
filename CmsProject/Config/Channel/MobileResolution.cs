using EPiServer.Web;

namespace CmsProject.Config.Channel
{
    public class MobileResolution : IDisplayResolution
    {
        public int Height
        {
            get { return 568; }
        }

        public string Id
        {
            get { return GetType().FullName; }
        }

        public string Name
        {
            get { return "Mobile (320x568)"; }
        }

        public int Width
        {
            get { return 320; }
        }
    }
}