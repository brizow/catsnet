using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CatsNet.Startup))]
namespace CatsNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
