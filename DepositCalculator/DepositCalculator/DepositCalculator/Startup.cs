using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DepositCalculator.Startup))]
namespace DepositCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
