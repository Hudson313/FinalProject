using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamApolloFinal.Startup))]
namespace TeamApolloFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
