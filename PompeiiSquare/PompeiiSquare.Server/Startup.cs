using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PompeiiSquare.Server.Startup))]
namespace PompeiiSquare.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
