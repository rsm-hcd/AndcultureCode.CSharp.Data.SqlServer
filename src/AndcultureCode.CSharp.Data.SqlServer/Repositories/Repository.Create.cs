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
using AndcultureCode.CSharp.Data.SqlServer.Extensions;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace AndcultureCode.CSharp.Data.SqlServer.Repositories
{
    /// <summary>
    /// SqlServer implementation for CRUD operations for <typeparamref name="T"/>
    /// </summary>
    public partial class Repository<T> : IRepository<T> where T : Entity
    {
        #region Public Methods

        public virtual IResult<List<T>> BulkCreate(IEnumerable<T> entities, long? createdById = default(long?))
        {
            var result = new Result<List<T>> { ResultObject = new List<T>() };
            if (entities == null || !entities.Any())
            {
                return result;
            }

            try
            {
                var entityList = entities.ToList();

                foreach (var entity in entityList)
                {
                    if (entity is ICreatable creatableEntity)
                    {
                        if (createdById.HasValue)
                        {
                            creatableEntity.CreatedById = createdById;
                        }
                        creatableEntity.CreatedOn = DateTimeOffset.UtcNow;
                    }
                }

                var index = 0;

                entityList.ForEach(e => e.Id = long.MinValue + index++);

                result.ResultObject.AddRange(entityList);

                // While utilizing EFCore, we must wrap our transaction inside a context created strategy
                // References:
                // - https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
                // - https://github.com/aspnet/EntityFrameworkCore/issues/7318
                var strategy = DbContext.Database.CreateExecutionStrategy();
                strategy.Execute(DbContext, operation: c =>
                {
                    using (var transaction = DbContext.Database.BeginTransaction())
                    {
                        DbContext.BulkInsert(entityList, new BulkConfig { BatchSize = 1000, PreserveInsertOrder = true, SetOutputIdentity = true, UseTempDB = true });
                        transaction.Commit();
                    }
                });
            }
            catch (Exception ex)
            {
                var errorKey = ex.GetType().ToString();
                var errorMessage = $"{ex.Message} -- {ex.InnerException?.Message}";
                Console.WriteLine($"{errorKey}: {errorMessage}");
                result.AddError(errorKey, errorMessage);
                result.ResultObject = null;
            }

            return result;
        }

        public Task<IResult<List<T>>> BulkCreateAsync(IEnumerable<T> items, long? createdById = null)
        {
            throw new NotImplementedException();
        }

        public virtual IResult<List<T>> BulkCreateDistinct<TKey>(IEnumerable<T> entities, Func<T, TKey> property, long? createdById = default(long?))
            => BulkCreate(entities.DistinctBy(property), createdById);

        public Task<IResult<List<T>>> BulkCreateDistinctAsync<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null)
        {
            throw new NotImplementedException();
        }

        public virtual IResult<T> Create(T entity, long? createdById = default(long?))
        {
            var result = new Result<T>();

            try
            {
                if (entity is ICreatable)
                {
                    if (createdById.HasValue)
                    {
                        ((ICreatable)entity).CreatedById = createdById;
                    }
                    ((ICreatable)entity).CreatedOn = DateTimeOffset.UtcNow;
                }

                Context.Add(entity);
                Context.DetectChanges(); // Note: New to EF Core, #SaveChanges, #Add and other methods do NOT automatically call DetectChanges
                Context.SaveChanges();

                result.ResultObject = entity;
            }
            catch (Exception ex)
            {
                result.AddError(ex.GetType().ToString(), $"{ex.Message} -- {ex.InnerException?.Message}");
            }

            return result;
        }

        public virtual IResult<List<T>> Create(IEnumerable<T> entities, long? createdById = default(long?))
        {
            var result = new Result<List<T>> { ResultObject = new List<T>() };

            try
            {
                var numInserted = 0;

                foreach (var entity in entities)
                {
                    if (entity is ICreatable)
                    {
                        if (createdById.HasValue)
                        {
                            ((ICreatable)entity).CreatedById = createdById;
                        }
                        ((ICreatable)entity).CreatedOn = DateTimeOffset.UtcNow;
                    }

                    Context.Add(entity);
                    result.ResultObject.Add(entity);

                    // Save in batches of 100, if there are at least 100 entities.
                    if (++numInserted >= 100)
                    {
                        numInserted = 0;

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

            return result;
        }

        public IResult<List<T>> CreateDistinct<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null)
            => Create(items.DistinctBy(property), createdById);

        public Task<IResult<T>> CreateAsync(T item, long? createdById = null)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<List<T>>> CreateAsync(IEnumerable<T> items, long? createdById = null)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<List<T>>> CreateDistinctAsync<TKey>(IEnumerable<T> items, Func<T, TKey> property, long? createdById = null)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}
