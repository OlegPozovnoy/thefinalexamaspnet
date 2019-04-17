using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VbFinal.Startup))]
namespace VbFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
