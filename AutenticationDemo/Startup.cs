using System;
using System.Threading.Tasks;
using System.Web.Http;
using AutenticationDemo.Providers;
using AuthenticationDemo;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(AutenticationDemo.Startup))]

namespace AutenticationDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseCors(CorsOptions.AllowAll); // enables cross origin http requests

            //// creating options object 
            //var OAuthOptions = new OAuthAuthorizationServerOptions
            //{
            //    AllowInsecureHttp = true,
            //    TokenEndpointPath = new PathString("/token"),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30), //token expiration time  
            //    Provider = new OAuthProvider() // OAuthProvider is a custom implementation
            //};

            //// configuring the application
            //app.UseOAuthBearerTokens(OAuthOptions);
            //app.UseOAuthAuthorizationServer(OAuthOptions);
            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
          
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
