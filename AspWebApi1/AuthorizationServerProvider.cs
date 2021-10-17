using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspWebApi1
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
                if(!ApiSecurity.Login(context.UserName, context.Password))
            {
                context.SetError("invalid_grant", "Username or password is incorrect");
                return;
            }
           
                /*var user = OBJ.ValidateUser(context.UserName, context.Password);
                if (user == "false")
                {
                    context.SetError("invalid_grant", "Username or password is incorrect");
                    return;
                }*/
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Role, "SuperAdmin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "akash"));
                //identity.AddClaim(new Claim("Email", user.UserEmailID));  

                context.Validated(identity);
          

        }
    }
}