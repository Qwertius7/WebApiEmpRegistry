using Ninject.Modules;
using Repository.impl;
using Repository.interfaces;

namespace Repository.config
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDepartmentRepository>().To<DepartmentRepository>();
            Bind<IEmployeeRepository>().To<EmployeeRepository>();
        }
    }
}