using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Core.Data;
using Warehouse.Core.Models;
using WarehouseService.Infrastructure.DataMapping;
using WarehouseService.Models;

namespace WarehouseService.Infrastructure.Data
{
    public class WarehouseDataContext: DbContext, IDbContext
    {
        public WarehouseDataContext(DbContextOptions<WarehouseDataContext> options)
            :base(options)
        {

        }

        #region IDbContext

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }


        /// <summary>
        /// Creates a LINQ query for the query type based on a raw SQL query
        /// </summary>
        /// <typeparam name="TQuery">Query type</typeparam>
        /// <param name="sql">The raw SQL query</param>
        /// <returns>An IQueryable representing the raw SQL query</returns>
        [Obsolete]
        public virtual IQueryable<TQuery> QueryFromSql<TQuery>(string sql) where TQuery : class
        {
            return this.Query<TQuery>().FromSql(sql);
        }

        /// <summary>
        /// Generate a script to create all tables for the current model
        /// </summary>
        /// <returns>A SQL script</returns>
        public virtual string GenerateCreateScript()
        {
            return this.Database.GenerateCreateScript();
        }

        public void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityEntry = this.Entry(entity);
            if (entityEntry == null)
                return;

            //set the entity is not being tracked by the context
            entityEntry.State = EntityState.Detached;
        }

        protected virtual string CreateSqlWithParameters(string sql, params object[] parameters)
        {
            //add parameters to sql
            for (var i = 0; i <= (parameters?.Length ?? 0) - 1; i++)
            {
                if (!(parameters[i] is DbParameter parameter))
                    continue;

                sql = $"{sql}{(i > 0 ? "," : string.Empty)} @{parameter.ParameterName}";

                //whether parameter is output
                if (parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Output)
                    sql = $"{sql} output";
            }

            return sql;
        }

        [Obsolete]
        public IQueryable<TEntity> EntityFromSql<TEntity>(string sql, params object[] parameters) where TEntity : BaseEntity
        {
            return RelationalQueryableExtensions.FromSql(Set<TEntity>().AsQueryable(), (RawSqlString)CreateSqlWithParameters(sql, parameters), parameters);
        }

        [Obsolete]
        public int ExecuteSqlCommand(RawSqlString sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            var previousTimeout = this.Database.GetCommandTimeout();
            this.Database.SetCommandTimeout(timeout);

            var result = 0;
            if (!doNotEnsureTransaction)
            {
                //use with transaction
                using (var transaction = this.Database.BeginTransaction())
                {
                    result = this.Database.ExecuteSqlCommand(sql, parameters);
                    transaction.Commit();
                }
            }
            else
                result = this.Database.ExecuteSqlCommand(sql, parameters);

            //return previous timeout back
            this.Database.SetCommandTimeout(previousTimeout);

            return result;
        }


        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMapConfiguration());
            builder.ApplyConfiguration(new StockSectorMapConfiguration());
            builder.ApplyConfiguration(new StockPositionMapConfiguration());
            builder.ApplyConfiguration(new StockBalanceMapConfiguration());
        }

    }

}
