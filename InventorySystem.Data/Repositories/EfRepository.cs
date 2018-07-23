using InventorySystem.Data.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace InventorySystem.Data.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        #region Fields

        private readonly IDbContext context;

        private IDbSet<T> entities;

        #endregion

        #region Ctor

        public EfRepository(IDbContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public virtual IQueryable<T> AsNoTracking
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (this.entities == null)
                {
                    this.entities = this.context.Set<T>();
                }

                return this.entities;
            }
        }

        public virtual T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Add(entity);

                ////this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                var fail = new Exception(msg, dbex);
                throw fail;
            }
        }

        public virtual void Update(T entity, bool changeState = true)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                if (changeState)
                {
                    this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                }

                ////this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                var fail = new Exception(msg, dbex);
                throw fail;
            }
        }

        public virtual void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                this.Entities.Remove(entity);

                ////this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                var fail = new Exception(msg, dbex);
                throw fail;
            }
        }

        public virtual IQueryable<T> GetAllLazyLoad(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] children)
        {
            IQueryable<T> query = this.Entities;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = children.Aggregate(query, (current, include) => current.Include(include));
            ////children.ToList().ForEach(x => query.Include(x));
            return query;
        }

        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : class
        {
            this.context.Db.CommandTimeout = 300;
            return this.context.ExecuteStoredProcedureList<TEntity>(commandText, parameters);
        }

        public IEnumerable<TElement> ExecuteStoredProcedure<TElement>(string commandText, params object[] parameters)
        {
            this.context.Db.CommandTimeout = 300;
            return this.context.SqlQuery<TElement>(commandText, parameters);
        }

        public IList<TEntity> ExecuteStoredProcedureListTmp<TEntity>(string commandText, params object[] parameters) where TEntity : class
        {
            this.context.Db.CommandTimeout = 300;
            return this.context.ExecuteStoredProcedureList<TEntity>(commandText, parameters);
        }

        public IEnumerable<TElement> ExecuteStoredProceduretmp<TElement>(string commandText, params object[] parameters)
        {
            this.context.Db.CommandTimeout = 300;
            return this.context.SqlQuery<TElement>(commandText, parameters);
        }

        public IEnumerable<TElement> ExecuteSql<TElement>(string commandText, params object[] parameters)
        {
            this.context.Db.CommandTimeout = 300;
            return this.context.ExecuteSql<TElement>(commandText, parameters);
        }

        #endregion
    }
}
