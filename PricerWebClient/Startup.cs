using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PricerWebClient.Startup))]
namespace PricerWebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
