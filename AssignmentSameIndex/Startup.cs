using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssignmentSameIndex.Startup))]
namespace AssignmentSameIndex
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
