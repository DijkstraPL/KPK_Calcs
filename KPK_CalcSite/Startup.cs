using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KPK_CalcSite.Startup))]
namespace KPK_CalcSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
