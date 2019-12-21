using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineShoppingBE.Startup))]
namespace OnlineShoppingBE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
