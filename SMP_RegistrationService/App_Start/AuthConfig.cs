using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Membership.OpenAuth;
using Microsoft.Web.WebPages.OAuth;

namespace SMP_RegistrationService
{
    internal static class AuthConfig
    {
        public static void RegisterOpenAuth()
        {
            // See http://go.microsoft.com/fwlink/?LinkId=252803 for details on setting up this ASP.NET
            // application to support logging in via external services.

            //OpenAuth.AuthenticationClients.AddTwitter(
            //    consumerKey: "your Twitter consumer key",
            //    consumerSecret: "your Twitter consumer secret");

            //OpenAuth.AuthenticationClients.AddFacebook(
            //    appId: "413826368722699",
            //    appSecret: "1d427d3e610632b9a75097afa5470646");

            OAuthWebSecurity.RegisterFacebookClient(
              appId: "413826368722699",
              appSecret: "1d427d3e610632b9a75097afa5470646");

            //OpenAuth.AuthenticationClients.AddMicrosoft(
            //    clientId: "your Microsoft account client id",
            //    clientSecret: "your Microsoft account client secret");

            //OpenAuth.AuthenticationClients.AddGoogle();

        }
    }
}