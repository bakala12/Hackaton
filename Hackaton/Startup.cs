using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hackaton.Startup))]
namespace Hackaton
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
