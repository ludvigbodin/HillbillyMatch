using Datalayer;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HillbillyMatch.Startup))]
namespace HillbillyMatch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Order matters here, otherwise SignalR wont get user information passed to IdProvider
            ConfigureAuth(app);
            //ConfigSignalR(app);
        }

        //private static void ConfigSignalR(IAppBuilder app)
        //{
        //    app.MapSignalR();
        //    var idProvider = new CustomUserIdProver();
        //    GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);
        //}
    }
}
