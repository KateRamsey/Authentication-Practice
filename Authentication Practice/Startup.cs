using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Authentication_Practice.Startup))]
namespace Authentication_Practice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
