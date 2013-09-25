using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using SMP_RegistrationService;
using SMP_RegistrationService.Contracts;
using WebMatrix.WebData;

namespace SMP_RegistrationService
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer<UsersContext>(null);

            try
            {
                using (var context = new UsersContext())
                {
                    if (!context.Database.Exists())
                    {
                        // Create the SimpleMembership database without Entity Framework migration schema
                        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                    }
                }

                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }
    }


}
