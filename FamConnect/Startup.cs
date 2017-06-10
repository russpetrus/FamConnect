using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FamConnect.Startup))]
namespace FamConnect
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
