using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DAV.Startup))]
namespace DAV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
