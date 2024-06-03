using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DotNetEnv;


namespace MoneyVision.Web
{
     public class Global : HttpApplication
     {
          void Application_Start(object sender, EventArgs e)
          {
               // Note: replace this stupid path with path of your .env file, running with ISS Express changes current directory so can't use relative path
               // Maybe will fix it later
               Env.Load("C:\\Users\\danie\\OneDrive\\Desktop\\utm\\tweb\\proiect\\.env");

               var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");

               if (!string.IsNullOrEmpty(connectionString))
               {
                    System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                    ConnectionStringsSection section = (ConnectionStringsSection)config.GetSection("connectionStrings");
                    section.ConnectionStrings["MoneyVision"].ConnectionString = connectionString;
                    config.Save();
               }

               // Code that runs on application startup
               AreaRegistration.RegisterAllAreas();
               RouteConfig.RegisterRoutes(RouteTable.Routes);
               BundleConfig.RegisterBundles(BundleTable.Bundles);
          }
     }
}