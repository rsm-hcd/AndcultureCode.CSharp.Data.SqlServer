using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AndcultureCode.CSharp.Data.SqlServer.Migrations
{
    /// <summary>
    /// Base class for migrations that have been flattened. Contains
    /// helper methods to validate if the flattened migration should
    /// run on a given database.
    /// 
    /// TODO: Tests should be written for this class at some point,
    /// see Github issue here: https://github.com/AndcultureCode/AndcultureCode.CSharp.Data.SqlServer/issues/2
    /// </summary>
    public abstract class FlattenedMigration : Migration
    {
        /// <summary>
        /// This should contain all flattened migration ID consts, in the order that they should
        /// be run.
        /// </summary>
        /// <value></value>
        public abstract List<string> FlattenedMigrations { get; }

        #region Overrides

        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        #endregion Overrides

        /// <summary>
        /// Should return the DbContext this migration works with. Recommend caching
        /// the context, and instantiating a new one on first get if the cached
        /// version has not yet been instantiated.
        /// </summary>
        /// <value></value>
        public abstract DbContext Context { get; }

        /// <summary>
        /// Outputs a given list of messages to the console running the migration.
        /// </summary>
        /// <param name="messages"></param>
        public void LogMigrationMessage(params string[] messages)
        {
            LogMigrationMessageLine("");
            LogMigrationMessageLine("------------------------------------------------");
            foreach (var m in messages)
            {
                LogMigrationMessageLine(m);
            }
            LogMigrationMessageLine("------------------------------------------------");
            LogMigrationMessageLine("");
        }

        /// <summary>
        /// Outputs a single message to the console running the migration, indicating the
        /// direction of the migration.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="direction"></param>
        public void LogMigrationMessageLine(string line, string direction = "Up")
        {
            var migrationName = this.GetType().Name;
            Console.WriteLine($"[Migration::{migrationName}#{direction}] {line}");
        }

        /// <summary>
        /// This will check if, based on the sort order of the other migrations, this flattened
        /// migration has not run on a fresh install.
        /// </summary>
        /// <param name="id">The ID of the flattened migration, as defined in the FlattenedMigrations list.</param>
        /// <returns>True indicates the migration should be run. False indicates you should abort
        /// running the migration, as this is not a fresh install, and the migration will likely fail.</returns>
        public bool ValidateFlattenedShouldRun(string id)
        {
            int count = 0;
            using (var connection = Context.Database.GetDbConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT COUNT(*) FROM [dbo].[__EFMigrationsHistory]";
                    string result = command.ExecuteScalar().ToString();

                    int.TryParse(result, out count);
                }
            }

            // If we have migrations after this one (this isn't a new DB), then abandon ship.
            var migrationPosition = FlattenedMigrations.OrderBy(e => e).ToList().FindIndex(0, e => e == id);
            if (count > migrationPosition)
            {
                return false;
            }

            return true;
        }
    }
}
