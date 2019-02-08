using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon.Repository.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> ListAll();

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void SaveAll();

        T FindById(object id);

        IEnumerable<T> ListByParameter(Func<T, bool> predicate);

        T FindByParameter(Func<T, bool> predicate);
    }
}
