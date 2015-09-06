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
                name: "DeleteAccount",
                url: "WhatsLeft/DeleteAccount/{accountId}",
                defaults: new { controller = "WhatsLeft", action = "DeleteAccount", accountId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditAccount",
                url: "Home/Details/{accountId}",
                defaults: new { controller = "Home", action = "Details", accountId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditRegularPayment",
                url: "Home/EditRegularPayment/{accountId}/{regularPaymentId}",
                defaults: new { controller = "Home", action = "EditRegularPayment" }
            );

            routes.MapRoute(
                name: "CreateRegularPayment",
                url: "Home/CreateRegularPayment/{accountId}",
                defaults: new { controller = "Home", action = "CreateRegularPayment" }
            );

            routes.MapRoute(
                name: "DeleteRegularPayment",
                url: "Home/DeleteRegularPayment/{accountId}/{regularPaymentId}",
                defaults: new { controller = "Home", action = "DeleteRegularPayment" }
            );

            routes.MapRoute(
                name: "CreateFund",
                url: "Home/CreateFund/{accountId}",
                defaults: new { controller = "Home", action = "CreateFund" }
            );

            routes.MapRoute(
                name: "DeleteFund",
                url: "Home/DeleteFund/{accountId}/{fundId}",
                defaults: new { controller = "Home", action = "DeleteFund" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
