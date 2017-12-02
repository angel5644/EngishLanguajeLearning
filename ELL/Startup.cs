using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ELL.Startup))]
namespace ELL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
