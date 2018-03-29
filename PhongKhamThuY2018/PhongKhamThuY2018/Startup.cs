using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhongKhamThuY2018.Startup))]
namespace PhongKhamThuY2018
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
