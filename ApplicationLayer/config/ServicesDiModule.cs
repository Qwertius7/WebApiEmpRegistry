using ApplicationLayer.interfaces;
using ApplicationLayer.services;
using ApplicationLayer.validators;
using Autofac;

namespace ApplicationLayer.config
{
    public class ServicesDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerRequest();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerRequest();
            builder.RegisterType<ProjectService>().As<IProjectService>().InstancePerRequest();

            builder.RegisterType<DepartmentValidator>().InstancePerLifetimeScope();
        }
    }
}