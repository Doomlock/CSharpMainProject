﻿using System;

namespace Warships
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(System.Web.Routing.RouteTable.Routes);
        }
    }
}