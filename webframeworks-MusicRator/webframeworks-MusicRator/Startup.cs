using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webframeworks_MusicRator.Startup))]
namespace webframeworks_MusicRator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
