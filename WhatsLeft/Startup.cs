using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhatsLeft.Startup))]
namespace WhatsLeft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
