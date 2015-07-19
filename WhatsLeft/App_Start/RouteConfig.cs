using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WhatsLeft
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "UpdateAccount",
                url: "WhatsLeft/Update/{bankAccountId}/{balance}",
                defaults: new { controller = "WhatsLeft", action = "Update", bankAccountId = UrlParameter.Optional, balance = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DeleteFund",
                url: "WhatsLeft/DeleteFund/{accountId}/{fundId}",
                defaults: new { controller = "WhatsLeft", action = "DeleteFund", accountId = UrlParameter.Optional, fundId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DeleteAccount",
                url: "WhatsLeft/DeleteAccount/{accountId}",
                defaults: new { controller = "WhatsLeft", action = "DeleteAccount", accountId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditAccount",
                url: "WhatsLeft/Edit/{accountId}",
                defaults: new { controller = "WhatsLeft", action = "Edit", accountId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
