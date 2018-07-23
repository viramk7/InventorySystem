using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace InventorySystem.Data.Database
{
    public partial class InventorySystemDBEntities : DbContext, IDbContext
    {
        public System.Data.Entity.Database Db
        {
            get
            {
                return this.Database;
            }
        }

        public DbContextConfiguration Configurationval
        {
            get
            {
                return this.Configuration;
            }
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : class
        {
            ////add parameters to command
            if (parameters != null && parameters.Length > 0)
            {
                for (int i = 0; i <= parameters.Length - 1; i++)
                {
                    var p = parameters[i] as DbParameter;
                    if (p == null)
                    {
                        throw new Exception("Not support parameter type");
                    }

                    commandText += i == 0 ? " " : ", ";

                    commandText += "@" + p.ParameterName;
                    if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                    {
                        ////output parameter
                        commandText += " output";
                    }
                }
            }

            return this.Database.SqlQuery<TEntity>(commandText, parameters).ToList();
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<TElement>(sql, parameters);
        }

        public IEnumerable<TElement> ExecuteSql<TElement>(string commandText, params object[] parameters)
        {
            if (parameters == null && parameters.Length <= 0)
                return Database.SqlQuery<TElement>(commandText, parameters);

            var count = 0;
            foreach (var param in parameters)
            {
                var p = param as DbParameter;

                if (p == null)
                    throw new Exception("Invalid parameter");

                commandText += count == 0 ? " " : ",";

                commandText += '@' + p.ParameterName;

                count++;
            }

            return Database.SqlQuery<TElement>(commandText, parameters);
        }
    }
}
