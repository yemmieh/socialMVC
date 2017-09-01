using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialCampaignMVC.Startup))]
namespace SocialCampaignMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
