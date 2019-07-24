using ApplicationLayer.interfaces;
using ApplicationLayer.services;
using Autofac;

namespace ApplicationLayer.config
{
    public class ServicesDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerRequest();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerRequest();
        }
    }
}