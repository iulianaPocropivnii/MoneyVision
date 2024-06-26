﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MoneyVision.Web
{
     public class RouteConfig
     {
          public static void RegisterRoutes(RouteCollection routes)
          {
               routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

               routes.MapRoute(
                   name: "Default",
                   url: "{controller}/{action}/{id}",
                   defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
               );

               routes.MapRoute(
                    name: "About",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional }
               );

               routes.MapRoute(
                    name: "Services",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Services", action = "Index", id = UrlParameter.Optional }
               );

               routes.MapRoute(
                    name: "Portfolio",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Portfolio", action = "Index", id = UrlParameter.Optional }
               );

               routes.MapRoute(
                    name: "Team",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Team", action = "Index", id = UrlParameter.Optional }
               );

               routes.MapRoute(
                    name: "Blog",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional }
               );

               routes.MapRoute(
                    name: "Contact",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
               );

               routes.MapRoute(
                    name: "Login",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
               );

               routes.MapRoute(
                    name: "Register",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Register", action = "Index", id = UrlParameter.Optional }
               );

               routes.MapRoute(
                    name: "Dashboard",
                    url: "Workspaces/{workspaceId}/{controller}/{action}/{id}",
                    defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
               );

               routes.MapRoute(
                    name: "Transactions",
                    url: "Workspaces/{workspaceId}/{controller}/{action}/{id}",
                    defaults: new { controller = "Transactions", action = "Index", id = UrlParameter.Optional }
               );

               routes.MapRoute(
                    name: "Logout",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Logout", action = "Index", id = UrlParameter.Optional }
               );
               routes.MapRoute(
                    name: "Users",
                    url: "Workspaces/{workspaceId}/{controller}/{action}/{id}",
                    defaults: new { controller = "Users", action = "Index", id = UrlParameter.Optional }
               );
          }
     }
}
