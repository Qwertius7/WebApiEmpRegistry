using System;
using System.Collections.Generic;
using data;

namespace Repository.operations.interfaces
{
    public abstract class DbOps<T>
    {
        protected readonly EmpRegistryContext Context;

        protected DbOps()
        {
            Context = new EmpRegistryContext();
        }

        protected DbOps(EmpRegistryContext context)
        {
            Context = context;
        }

        public abstract IEnumerable<T> GetAll();
        public abstract T GetById(Guid id);
        public abstract T Create(T emp);
        public abstract T Update(T emp);
        public abstract T DeleteById(Guid id);
    }
}