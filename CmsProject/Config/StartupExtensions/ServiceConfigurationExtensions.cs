using Microsoft.Extensions.DependencyInjection;
using CmsProject.Models.Blocks.FrontCover;
using EPiServer.Cms.TinyMce.Core;

namespace CmsProject.Config.StartupExtensions
{
    public static class ServiceConfigurationExtensions
    {
        public static void AddTinyMceConfiguration(this IServiceCollection services)
        {
            services.Configure<TinyMceConfiguration>(config =>
            {
                config.Default()
                    .AddPlugin("media", "wordcount", "anchor", "code", "textcolor", "colorpicker")
                    .AddSetting("image_caption", true)
                    .AddSetting("extended_valid_elements", "i[class], span");

                config.Default().AddEpiserverSupport()
                    //.AddExternalPlugin("icons", "/ClientResources/Scripts/fontawesomeicons.js")
                    .AddSetting("image_advtab", true)
                    .ContentCss(new[]
                    {
                        //"/ClientResources/Styles/fontawesome.min.css",
                        "https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i",
                        "/ClientResources/Styles/TinyMCE.css"
                    });

                config
                .Default()
                .Toolbar("formatselect bold italic underline forecolor backcolor alignleft aligncenter alignright numlist bullist indent outdent removeformat", "epi-personalized-content epi-link anchor image epi-image-editor media code epi-dnd-processor fullscreen");
            });
        }
    }
}