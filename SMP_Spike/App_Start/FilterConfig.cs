﻿using System.Web;
using System.Web.Mvc;

namespace SMP_Spike
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}