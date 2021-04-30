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
    /// SqlServer implementation for DELETE operations for <typeparamref name="T"/>
    /// </summary>
    public partial class Repository<T> : IRepository<T> where T : Entity
    {
        #region Constants

        /// <summary>
        /// Entity could not be deleted as it does not exist
        /// </summary>
        public const string ERROR_DELETE_MISSING_ENTITY = "Repository.Delete.MissingEntity";

        /// <summary>
        /// Entity cannot be soft deleted
        /// </summary>
        public const string ERROR_DELETE_SOFT_DELETION_NOT_IDELETEABLE = "Repository.Delete.SoftDeletionNotIDeleteable";

        #endregion Constants

        #region Public Methods

        public IResult<bool> BulkDelete(IEnumerable<T> entities, long? deletedById = null, bool soft = true)
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
                    if (!(entity is IDeletable))
                    {
                        continue;
                    }

                    if (deletedById.HasValue)
                    {
                        ((IDeletable)entity).DeletedById = deletedById;
                    }
                    ((IDeletable)entity).DeletedOn = DateTimeOffset.UtcNow;
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
                        if (soft)
                        {
                            DbContext.BulkUpdate(entities.ToList(), new BulkConfig { BatchSize = 1000, UseTempDB = true });
                            transaction.Commit();
                        }
                        else
                        {
                            DbContext.BulkDelete(entities.ToList(), new BulkConfig { BatchSize = 1000 });
                            transaction.Commit();
                        }

                    }
                });
            }
            catch (Exception ex)
            {
                var errorKey = ex.GetType().ToString();
                var errorMessage = $"{ex.Message} -- {ex.InnerException?.Message}";
                Console.WriteLine($"{errorKey}: {errorMessage}");
                result.AddError(errorKey, errorMessage);
                result.ResultObject = false;
                return result;
            }

            result.ResultObject = true;

            return result;
        }

        public Task<IResult<bool>> BulkDeleteAsync(IEnumerable<T> items, long? deletedById = null, bool soft = true)
        {
            throw new NotImplementedException();
        }

        public virtual IResult<bool> Delete(long id, long? deletedById = default(long?), bool soft = true)
        {
            var findResult = FindById(id, true);

            if (findResult.HasErrors)
            {
                return new Result<bool>
                {
                    Errors = findResult.Errors,
                    ResultObject = false
                };
            }

            return Delete(findResult.ResultObject, deletedById, soft);
        }

        public virtual IResult<bool> Delete(T entity, long? deletedById = default(long?), bool soft = true)
        {
            var result = new Result<bool> { ResultObject = false };

            try
            {
                if (entity == null)
                {
                    result.AddError(_localizer, ERROR_DELETE_MISSING_ENTITY, $"{entity.GetType()}");
                    return result;
                }

                if (soft && !(entity is IDeletable))
                {
                    result.AddError(_localizer, ERROR_DELETE_SOFT_DELETION_NOT_IDELETEABLE);
                    return result;
                }

                if (soft)
                {
                    if (deletedById.HasValue)
                    {
                        ((IDeletable)entity).DeletedById = deletedById;
                    }
                    ((IDeletable)entity).DeletedOn = DateTimeOffset.UtcNow;
                }
                else
                {
                    Context.Delete(entity);
                }

                Context.SaveChanges();
                result.ResultObject = true;
            }
            catch (Exception ex)
            {
                result.AddError(ex.GetType().ToString(), ex.Message);
            }

            return result;
        }

        public virtual IResult<bool> Delete(IEnumerable<T> entities, long? deletedById = default(long?), long batchSize = 100, bool soft = true)
        {
            var result = new Result<bool>();

            try
            {
                var numDeleted = 0;

                foreach (var entity in entities)
                {
                    if (entity == null)
                    {
                        result.AddError(_localizer, ERROR_DELETE_MISSING_ENTITY, $"{entity.GetType()}");
                        continue;
                    }

                    if (soft && !(entity is IDeletable))
                    {
                        result.AddError(
                            _localizer,
                            ERROR_DELETE_SOFT_DELETION_NOT_IDELETEABLE
                        );
                        return result;
                    }

                    if (soft)
                    {
                        if (deletedById.HasValue)
                        {
                            ((IDeletable)entity).DeletedById = deletedById;
                        }
                        ((IDeletable)entity).DeletedOn = DateTimeOffset.UtcNow;
                    }
                    else
                    {
                        Context.Delete(entity);
                    }

                    if (++numDeleted >= batchSize)
                    {
                        numDeleted = 0;

                        Context.DetectChanges(); // Note: New to EF Core, #SaveChanges, #Add and other methods do NOT automatically call DetectChanges
                        Context.SaveChanges();
                    }
                }

                // Save whatever is left over.
                Context.DetectChanges(); // Note: New to EF Core, #SaveChanges, #Add and other methods do NOT automatically call DetectChanges
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.AddError(ex.GetType().ToString(), $"{ex.Message} -- {ex.InnerException?.Message}");
            }

            result.ResultObject = !result.HasErrors;

            return result;
        }

        public Task<IResult<bool>> DeleteAsync(long id, long? deletedById = null, bool soft = true)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<bool>> DeleteAsync(T o, long? deletedById = null, bool soft = true)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<bool>> DeleteAsync(IEnumerable<T> items, long? deletedById = null, long batchSize = 100, bool soft = true)
        {
            throw new NotImplementedException();
        }

        public virtual IResult<bool> Restore(long id)
        {
            var result = new Result<bool> { ResultObject = false };

            try
            {
                var findResult = FindById(id);
                if (findResult.HasErrors)
                {
                    result.AddErrors(findResult.Errors);
                    return result;
                }

                var restoreResult = Restore(findResult.ResultObject);
                if (restoreResult.HasErrors)
                {
                    result.AddErrors(restoreResult.Errors);
                    return result;
                }

                result.ResultObject = true;
            }
            catch (Exception ex)
            {
                result.AddError(ex.GetType().ToString(), ex.Message);
            }

            return result;
        }

        public virtual IResult<bool> Restore(T entity)
        {
            var result = new Result<bool> { ResultObject = false };

            try
            {
                if (entity is IDeletable)
                {
                    ((IDeletable)entity).DeletedById = null;
                    ((IDeletable)entity).DeletedOn = null;
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

        public Task<IResult<bool>> RestoreAsync(T o)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<bool>> RestoreAsync(long id)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}
