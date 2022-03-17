using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;

namespace CmsProject.Config.ViewLocationExpander
{
    public class SimpleViewLocationExpander : IViewLocationExpander
    {
        private readonly List<string> newLocations = new()
        {
            "/Models/Pages/{1}/{0}.cshtml",
            "/Models/Pages/{1}/{1}.cshtml"
        };

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            foreach (var location in newLocations.Union(viewLocations))
            {
                yield return location;
            }
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            //Debug.WriteLine(context.ViewName);
        }
    }
}