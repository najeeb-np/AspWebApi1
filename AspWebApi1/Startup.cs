using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspWebApi1.Startup))]
namespace AspWebApi1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
