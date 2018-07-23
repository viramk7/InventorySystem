using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InventorySystem.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsNoTracking { get; }

        IQueryable<T> Table { get; }

        T GetById(object id);

        void Insert(T entity);

        void Update(T entity, bool changeState = true);

        void SaveChanges();

        void Delete(T entity);

        IQueryable<T> GetAllLazyLoad(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] children);

        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : class;

        IEnumerable<TElement> ExecuteStoredProcedure<TElement>(string commandText, params object[] parameters);

        IList<TEntity> ExecuteStoredProcedureListTmp<TEntity>(string commandText, params object[] parameters) where TEntity : class;

        IEnumerable<TElement> ExecuteStoredProceduretmp<TElement>(string commandText, params object[] parameters);

        IEnumerable<TElement> ExecuteSql<TElement>(string commandText, params object[] parameters);
    }
}
