using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PangXieKX.Plathform.Startup))]
namespace PangXieKX.Plathform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
