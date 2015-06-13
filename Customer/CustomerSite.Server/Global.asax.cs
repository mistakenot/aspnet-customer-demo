using CustomerSite.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CustomerSite.Server
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CustomerDataContext.ConnectionString = WebConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            ClearDatabase();
        }

        /// <summary>
        /// Used strictly for debugging. This clears all entries in the Database.
        /// </summary>
        private void ClearDatabase()
        {
            using (var db = new CustomerDataContext())
            {
                db.Customers.RemoveRange(
                    db.Customers.ToList()
                );
                db.SaveChanges();
            }
        }
    }
}
