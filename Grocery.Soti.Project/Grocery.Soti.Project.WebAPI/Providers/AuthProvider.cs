using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Grocery.Soti.Project.WebAPI.Providers
{
    public class AuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }



        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //UserDetails userDetails = new UserDetails();
            //var user = await userDetails.ValidateUserAsync(context.UserName, context.Password);
            //if (user != null)
            //{
            //    var identity = new ClaimsIdentity(context.Options.AuthenticationType);//Bearer Token
            //    identity.AddClaim(new Claim(ClaimTypes.Email, user.EmailId));
            //    identity.AddClaim(new Claim(ClaimTypes.MobilePhone, user.MobileNumber));
            //    context.Validated(identity);
            //}
            //else
            //{
            //    context.SetError("Invalid Details", "Either Username or Password is incorrect");
            //    return;
            //}
        }
    }
}