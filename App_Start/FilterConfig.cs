﻿using System.Web;
using System.Web.Mvc;

namespace VideoProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); //this will apply for all controller
        }
    }
}
