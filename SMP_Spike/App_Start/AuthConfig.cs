using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetOpenAuth.AspNet;
using DotNetOpenAuth.AspNet.Clients;
using Microsoft.Web.WebPages.OAuth;
using SMP_Spike.Models;

namespace SMP_Spike
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            OAuthWebSecurity.RegisterFacebookClient(
              appId: "[ENTER_FACEBOOK_APP_ID_HERE]",
              appSecret: "[ENTER_APP_SECRET_HERE]");

            //IAuthenticationClient client = new OpenIdClient();
            //OAuthWebSecurity.RegisterClient();

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
