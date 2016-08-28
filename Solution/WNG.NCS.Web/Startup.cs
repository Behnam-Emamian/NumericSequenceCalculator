using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WNG.NCS.Web.Startup))]
namespace WNG.NCS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
