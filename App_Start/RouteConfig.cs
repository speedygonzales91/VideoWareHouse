﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VideoProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    name: "MoviesByRelease",
            //    url: "movies/release/{year}/{month}",
            //    defaults: new
            //    {
            //        controller = "movies",
            //        action = "ByReleaseDate"
            //    },
            //    constraints: new
            //    {
            //        year = @"/d{4}",
            //        month = @"/d{2}"
            //    });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
