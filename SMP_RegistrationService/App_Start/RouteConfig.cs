using System;
using System.Collections.Generic;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using Conduit.Mobile.Contracts;
using Microsoft.AspNet.FriendlyUrls;
using SMP_RegistrationService.Service;

namespace SMP_RegistrationService
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.EnableFriendlyUrls();

            routes.Add(new ServiceRoute("", new JsonWebServiceHostFactory(),
                typeof(RegistrationManagerImplementation)));
        }
    }
}
