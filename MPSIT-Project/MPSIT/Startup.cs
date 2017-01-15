using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MPSIT.Startup))]
namespace MPSIT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
