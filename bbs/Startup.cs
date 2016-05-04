using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bbs.Startup))]
namespace bbs
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
