using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Comment1.Startup))]
namespace Comment1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
