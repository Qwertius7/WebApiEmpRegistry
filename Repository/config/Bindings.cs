using Ninject.Modules;
using Repository.dto;
using Repository.impl;
using Repository.interfaces;
using Repository.operations;
using Repository.operations.interfaces;

namespace Repository.config
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<DbOps<DepartmentDto>>().To<DepartmentOps>();
            Bind<DbOps<EmployeeDto>>().To<EmployeeOps>();
            Bind<IGenericRepository>().To<GenericDbRepository>();
        }
    }
}