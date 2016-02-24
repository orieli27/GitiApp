using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dataHandler.Startup))]
namespace dataHandler
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
