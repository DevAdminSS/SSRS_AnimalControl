using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimalControl.Startup))]
namespace AnimalControl
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
