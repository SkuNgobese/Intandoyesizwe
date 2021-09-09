using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Intandoyesizwe.Startup))]
namespace Intandoyesizwe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
