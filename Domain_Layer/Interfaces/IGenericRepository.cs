using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain_Layer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> Find(Expression<Func<T, bool>> predicate);
    }
}
