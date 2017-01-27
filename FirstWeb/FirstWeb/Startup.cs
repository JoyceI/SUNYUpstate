using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirstWeb.Startup))]
namespace FirstWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
