using System;
using System.Linq;
using AndcultureCode.CSharp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace AndcultureCode.CSharp.Data.SqlServer
{
    /// <summary>
    /// Base implementation of a generic dbcontext
    /// </summary>
    public abstract class SqlServerContext : DbContext, IContext
    {
        #region Member Variables

        private readonly string _connectionString = "";
        private readonly ILoggerFactory _loggerFactory;

        #endregion Member Variables

        #region Constructors

        public SqlServerContext() {}
        public SqlServerContext(string connectionString, ILoggerFactory loggerFactory)
        {
            _connectionString = connectionString;
            _loggerFactory = loggerFactory;
        }

        #endregion Constructors

        #region Overrides

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_loggerFactory != null)
            {
                optionsBuilder.UseLoggerFactory(_loggerFactory);
            }

            optionsBuilder.UseSqlServer(_connectionString, options => options.EnableRetryOnFailure(3, TimeSpan.FromSeconds(30), null));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Remove cascade delete
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Configure mappings
            ConfigureMappings(modelBuilder);

            // Call the base method
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges() => base.SaveChanges();

        #endregion Overrides

        #region IDataContext Implementation

        /// <summary>
        /// Gets the context ready for adding the entity, does not save the changes on the context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public new void Add<T>(T entity) where T : class => base.Add(entity);

        /// <summary>
        /// Bring the database up to the latest migration
        /// </summary>
        public virtual void CreateStructure()
        {
        }

        public virtual void DeleteDatabase()
        {
        }

        /// <summary>
        /// Gets the context ready for removing the entity, does not save the changes on the context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Delete<T>(T entity) where T : class
        {
            var set = base.Set<T>();
            set.Remove(entity);
        }

        public void DetectChanges() => base.ChangeTracker.DetectChanges();

        /// <summary>
        /// Remove all context items from the database
        /// </summary>
        public virtual void DropStructure()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public new IQueryable<T> Query<T>() where T : class => base.Set<T>();

        /// <summary>
        /// Gets the context ready for updating the entity, does not save the changes on the context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public new void Update<T>(T entity) where T : class
        {
            var set = base.Set<T>();

            if (!set.Local.Any(e => e == entity))
            {
                set.Attach(entity);
                SetAsModified(entity);
            }
        }

        #endregion IDataContext Implementation

        #region Public Methods

        /// <summary>
        /// Configure the mappings for the context
        /// </summary>
        public virtual void ConfigureMappings(ModelBuilder modelBuilder)
        {
        }

        public virtual long ExecuteCommand(string commandText) => base.Database.ExecuteSqlCommand(commandText);

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Get the entity entry
        /// </summary>
        private EntityEntry GetEntityEntry<T>(T entity) where T : class
        {
            var entry = Entry<T>(entity);

            if (entry.State == EntityState.Deleted)
            {
                (Set<T>() as DbSet<T>).Attach(entity);
            }

            return entry;
        }

        /// <summary>
        /// Set the entity as being added
        /// </summary>
        private void SetAsAdded<T>(T entity) where T : class
        {
            UpdateEntityState(entity, EntityState.Added);
        }

        /// <summary>
        /// Set the entity as being deleted
        /// </summary>
        private void SetAsDeleted<T>(T entity) where T : class
        {
            UpdateEntityState(entity, EntityState.Deleted);
        }

        /// <summary>
        /// Set the entity as detached
        /// </summary>
        private void SetAsDetached<T>(T entity) where T : class
        {
            UpdateEntityState(entity, EntityState.Detached);
        }

        /// <summary>
        /// Set the entity as being modified
        /// </summary>
        private void SetAsModified<T>(T entity) where T : class
        {
            UpdateEntityState(entity, EntityState.Modified);
        }

        /// <summary>
        /// Update the entity state for the specified entity
        /// </summary>
        private void UpdateEntityState<T>(T entity, EntityState state) where T : class
        {
            GetEntityEntry(entity).State = state;
        }

        #endregion Private Methods
    }
}
