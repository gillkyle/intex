using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NL.Startup))]
namespace NL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
