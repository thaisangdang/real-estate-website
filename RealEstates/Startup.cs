using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RealEstates.Startup))]
namespace RealEstates
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
