using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserRole.Startup))]
namespace UserRole
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
