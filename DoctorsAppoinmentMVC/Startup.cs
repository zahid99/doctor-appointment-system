using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoctorsAppoinmentMVC.Startup))]
namespace DoctorsAppoinmentMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
