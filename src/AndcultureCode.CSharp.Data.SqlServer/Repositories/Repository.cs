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
        #region Private Members

        private readonly IStringLocalizer _localizer;

        #endregion Private Members

        #region Properties

        public IContext Context { get; private set; }
        private DbContext DbContext { get => (DbContext)Context; }
        public IQueryable<T> Query { get; private set; }

        public int? CommandTimeout
        {
            get
            {
                if (Context != null && Context is DbContext)
                {
                    return DbContext.Database.GetCommandTimeout();
                }

                return null;
            }
            set
            {
                if (Context != null && Context is DbContext)
                {
                    DbContext.Database.SetCommandTimeout(value);
                }
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Default constructor injecting the data context
        /// </summary>
        public Repository(IContext context, IStringLocalizer localizer)
        {
            Context = context;
            Query = context.Query<T>();

            _localizer = localizer;
        }

        #endregion Constructors
    }
}
