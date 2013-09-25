using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using Conduit.Mobile.Contracts;
using Microsoft.AspNet.Membership.OpenAuth;
using SMP_RegistrationService.Contracts;
using WebMatrix.WebData;
using Conduit.Mobile;
using Microsoft.Web.WebPages.OAuth;

namespace SMP_RegistrationService.Service
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Prefix)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [CacheControl]
    [AutoResponseFormat(WebMessageFormat.Json)]
    public class RegistrationManagerImplementation : IRegistrationManager
    {
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "{provider=0}/?user={user}&password={pw}")]
        public Response<bool> Register(string provider, string user, string pw)
        {
            return Helpers.Execute(() =>
                {
                    if (string.IsNullOrEmpty(user) && string.IsNullOrEmpty(pw))
                        return false;

                    switch (provider)
                    {
                        case "0":
                            if (!WebSecurity.UserExists(user))
                                WebSecurity.CreateUserAndAccount(user, pw);
                            else
                                throw new Exception("user already exists!");
                            break;

                        case "1":
                            OAuthWebSecurity.RequestAuthentication("facebook", "http://localhost:22132/CompleteRegistration");
                           break;
                    }
                    
                    return true;
                }, true);
            
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/{url}")]
        public Response<bool> CompleteRegistration(string url)
        {
            return Helpers.Execute(() =>
                {
                    
                    var res = OAuthWebSecurity.VerifyAuthentication(); 

                    using (UsersContext db = new UsersContext())
                    {
                        var ps = db.UserProfiles;

                        UserProfile user = db.UserProfiles
                                             .FirstOrDefault(u => u.UserName.ToLower() == res.UserName.ToLower());
                        // Check if user already exists
                        if (user == null)
                        {
                            // Insert name into the profile table
                            db.UserProfiles.Add(new UserProfile {UserName = res.UserName});
                            db.SaveChanges();

                            OAuthWebSecurity.CreateOrUpdateAccount("facebook", res.ProviderUserId, res.UserName);
                        }
                    }

                    return true;
                }, true);
        }
    }
}