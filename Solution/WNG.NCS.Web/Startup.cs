using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PersianProcess.NCS.Web.Startup))]
namespace PersianProcess.NCS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
