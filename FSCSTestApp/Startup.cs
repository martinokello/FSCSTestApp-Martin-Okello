using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FSCSTestApp.Startup))]
namespace FSCSTestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
