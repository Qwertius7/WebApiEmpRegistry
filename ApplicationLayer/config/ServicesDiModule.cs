using System.Web.Http;
using ApplicationLayer.interfaces;
using ApplicationLayer.services;
using Ninject.Modules;
using Ninject.Web.WebApi.Filter;

namespace ApplicationLayer.config
{
    public class ServicesDiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DefaultFilterProviders>().ToConstant(new DefaultFilterProviders(GlobalConfiguration.Configuration.Services.GetFilterProviders()));
            Bind<IDepartmentService>().To<DepartmentService>();
            Bind<IEmployeeService>().To<EmployeeService>();
        }
    }
}