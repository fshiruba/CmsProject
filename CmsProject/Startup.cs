using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CmsProject.Config.ViewLocationExpander;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Web.Routing;

namespace CmsProject
{
    public class Startup
    {
        public Startup(IWebHostEnvironment webHostingEnvironment)
        {
            _webHostingEnvironment = webHostingEnvironment;
        }

        private readonly IWebHostEnvironment _webHostingEnvironment;

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
            }

            app.UseDetection();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapContent());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_webHostingEnvironment.IsDevelopment())
            {
                //Add development configuration
            }

            services.AddDetection();

            // Needed by Wangkanai Detection
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services
                .AddMvc(/*o => o.Conventions.Add(new CmsConvention())*/)
                .AddRazorOptions(ro => ro.ViewLocationExpanders.Add(new SimpleViewLocationExpander()));

            services
                .AddCms()
                .AddCmsAspNetIdentity<ApplicationUser>();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/util/Login");
        }
    }
}