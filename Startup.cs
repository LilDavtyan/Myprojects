using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Les8.Startup))]
namespace Les8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
