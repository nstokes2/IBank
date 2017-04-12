using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoIBank.Startup))]
namespace DemoIBank
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
