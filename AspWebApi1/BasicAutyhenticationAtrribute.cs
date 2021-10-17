using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AspWebApi1
{
    public class BasicAuthenticationAtrribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                var authenticationDetails = actionContext.Request.Headers.Authorization.Parameter;
                var decodedAuthenticationDetails = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationDetails));
                var userPassArray = decodedAuthenticationDetails.Split(':');
                var user = userPassArray[0];
                var pass = userPassArray[1];
                if(ApiSecurity.Login(user, pass))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(user), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}