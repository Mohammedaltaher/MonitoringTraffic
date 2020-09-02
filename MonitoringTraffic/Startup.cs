using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonitoringTraffic.Startup))]
namespace MonitoringTraffic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
