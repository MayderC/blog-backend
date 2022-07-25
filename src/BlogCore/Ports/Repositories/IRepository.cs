using System;
using System.Collections.Generic;

namespace BlogCore.Ports.Repositories
{
    public interface IRepository<T> where T : class
    {

        T GetById(Guid id);

        void DeleteById(T id);

        void UpdateById(T entity);

        IEnumerable<T> GetAll();

        void Save (T entity);


    }
}
