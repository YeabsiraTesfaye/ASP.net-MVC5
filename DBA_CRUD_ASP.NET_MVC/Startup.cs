using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DBA_CRUD_ASP.NET_MVC.Startup))]
namespace DBA_CRUD_ASP.NET_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
