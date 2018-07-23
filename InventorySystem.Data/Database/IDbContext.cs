using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace InventorySystem.Data.Database
{
    public interface IDbContext
    {
        DbContextConfiguration Configurationval { get; }

        System.Data.Entity.Database Db { get; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : class;

        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        DbEntityEntry Entry(object entity);

        IEnumerable<TElement> ExecuteSql<TElement>(string commandText, params object[] parameters);
    }
}
