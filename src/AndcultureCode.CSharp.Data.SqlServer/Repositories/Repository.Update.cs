using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core;
using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Interfaces.Entity;
using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Core.Models.Entities;
using AndcultureCode.CSharp.Core.Models.Errors;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace AndcultureCode.CSharp.Data.SqlServer.Repositories
{
    /// <summary>
    /// SqlServer implementation for UPDATE operations for <typeparamref name="T"/>
    /// </summary>
    public partial class Repository<T> : IRepository<T> where T : Entity
    {
        #region Public Methods

        public virtual IResult<bool> BulkUpdate(IEnumerable<T> entities, long? updatedBy = default(long?))
        {
            var result = new Result<bool> { ResultObject = false };
            if (entities == null || !entities.Any())
            {
                result.ResultObject = true;
                return result;
            }

            try
            {
                foreach (var entity in entities)
                {
                    if (entity is IUpdatable)
                    {
                        ((IUpdatable)entity).UpdatedById = updatedBy;
                        ((IUpdatable)entity).UpdatedOn = DateTimeOffset.UtcNow;
                    }
                }

                // While utilizing EFCore, we must wrap our transaction inside a context created strategy
                // References:
                // - https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
                // - https://github.com/aspnet/EntityFrameworkCore/issues/7318
                var strategy = DbContext.Database.CreateExecutionStrategy();
                strategy.Execute(DbContext, operation: c =>
                {
                    using (var transaction = DbContext.Database.BeginTransaction())
                    {
                        DbContext.BulkUpdate(entities.ToList(), new BulkConfig { UseTempDB = true });
                        transaction.Commit();
                    }
                });

                result.ResultObject = true;
            }
            catch (Exception ex)
            {
                var errorKey = ex.GetType().ToString();
                var errorMessage = $"{ex.Message} -- {ex.InnerException?.Message}";
                Console.WriteLine($"{errorKey}: {errorMessage}");
                result.AddError(errorKey, errorMessage);
                result.ResultObject = false;
            }

            return result;
        }

        public Task<IResult<bool>> BulkUpdateAsync(IEnumerable<T> entities, long? updatedBy = null)
        {
            throw new NotImplementedException();
        }

        public virtual IResult<bool> Update(T entity, long? updatedBy = default(long?))
        {
            var result = new Result<bool> { ResultObject = false };

            try
            {
                if (entity is IUpdatable)
                {
                    ((IUpdatable)entity).UpdatedById = updatedBy;
                    ((IUpdatable)entity).UpdatedOn = DateTimeOffset.UtcNow;
                }

                Context.Update(entity);
                Context.SaveChanges();

                result.ResultObject = true;
            }
            catch (Exception ex)
            {
                result.AddError(ex.GetType().ToString(), ex.Message);
            }

            return result;
        }

        public virtual IResult<bool> Update(IEnumerable<T> entities, long? updatedBy = default(long?)) => Do<bool>.Try((r) =>
        {
            var numUpdated = 0;

            foreach (var entity in entities)
            {
                if (entity is IUpdatable)
                {
                    ((IUpdatable)entity).UpdatedById = updatedBy;
                    ((IUpdatable)entity).UpdatedOn = DateTimeOffset.UtcNow;
                }

                Context.Update(entity);

                // Save in batches of 100, if there are at least 100 entities.
                if (++numUpdated >= 100)
                {
                    numUpdated = 0;

                    Context.SaveChanges();
                }
            }

            // Save whatever is left over.
            Context.SaveChanges();

            return true;
        })
        .Result;

        public Task<IResult<bool>> UpdateAsync(T item, long? updatedBy = null)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<bool>> UpdateAsync(IEnumerable<T> entities, long? updatedBy = null)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}
