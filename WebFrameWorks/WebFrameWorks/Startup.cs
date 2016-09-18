using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFrameWorks.Startup))]
namespace WebFrameWorks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
