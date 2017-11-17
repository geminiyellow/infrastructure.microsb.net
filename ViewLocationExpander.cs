using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Microsb.Infrastructure
{
    public class ViewLocationExpander : IViewLocationExpander
    {
        //{2} is area, {1} is controller,{0} is the action
        readonly string[] ViewLocationFormats = {
            "~/{1}/{0}.cshtml",
            "~/{1}/{0}.vbhtml",
            "~/Shared/{1}/{0}.cshtml",
            "~/Shared/{1}/{0}.vbhtml"
        };

        /// <summary>
        /// Used to specify the locations that the view engine should search to locate views.
        /// https://aspnetwebstack.codeplex.com/SourceControl/latest#src/System.Web.Mvc/RazorViewEngine.cs
        /// </summary>
        /// <param name="context"></param>
        /// <param name="viewLocations"></param>
        /// <returns></returns>
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            //Add mvc default locations after ours
            return ViewLocationFormats.Union(viewLocations);
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["customviewlocation"] = nameof(ViewLocationExpander);
        }
    }
}


