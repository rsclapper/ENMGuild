using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuildENM.Startup))]
namespace GuildENM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
