using System.Web.Http;
using Ninject.Http;

namespace WebApiEmpRegistry
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            NinjectHttpContainer.RegisterModules(NinjectHttpModules.Modules);
        }
    }
}
