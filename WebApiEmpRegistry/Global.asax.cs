using System.Web.Http;
using ApplicationLayer.config;
using ApplicationLayer.config.automapper;
using Autofac;
using Autofac.Integration.WebApi;
using Repository.config;
using WebApiEmpRegistry.Controllers;

namespace WebApiEmpRegistry
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            var builder = new ContainerBuilder();
//            builder.RegisterApiControllers();
            builder.RegisterType<DepController>().InstancePerRequest();
            builder.RegisterType<EmpController>().InstancePerRequest();
            builder.RegisterType<ProjController>().InstancePerRequest();
//            builder.RegisterAssemblyModules();
            builder.RegisterModule(new Bindings());
            builder.RegisterModule(new ServicesDiModule());
            builder.RegisterModule(new AutomapperDiModule());
            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
