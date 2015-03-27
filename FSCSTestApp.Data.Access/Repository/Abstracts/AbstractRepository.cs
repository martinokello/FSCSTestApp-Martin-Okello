using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSCSTestApp.Data.Access.Factories;
using FSCSTestApp.Data.Access.Repository.Interfaces;

namespace FSCSTestApp.Data.Access.Repository.Abstracts
{
    public abstract class AbstractRepository<T, TKey> : IRepository<T, TKey> where T : class
    {
        public abstract T GetById(TKey key);

        public virtual T[] GetAll()
        {
            return DBContextFactory.GetDbContextInstance().Set<T>().ToArray<T>();
        }

        public abstract TKey Add(T instance);

        public abstract bool Delete(TKey key);

        public abstract bool Update(T instance);
    }
}
