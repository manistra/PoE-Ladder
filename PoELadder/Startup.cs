using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PoELadder.Startup))]
namespace PoELadder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
