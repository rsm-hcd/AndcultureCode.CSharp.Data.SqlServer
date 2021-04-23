<a name='assembly'></a>
# AndcultureCode.CSharp.Data.SqlServer

## Contents

- [FlattenedMigration](#T-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration 'AndcultureCode.CSharp.Data.SqlServer.Migrations.FlattenedMigration')
  - [Context](#P-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-Context 'AndcultureCode.CSharp.Data.SqlServer.Migrations.FlattenedMigration.Context')
  - [FlattenedMigrations](#P-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-FlattenedMigrations 'AndcultureCode.CSharp.Data.SqlServer.Migrations.FlattenedMigration.FlattenedMigrations')
  - [LogMigrationMessage(messages)](#M-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-LogMigrationMessage-System-String[]- 'AndcultureCode.CSharp.Data.SqlServer.Migrations.FlattenedMigration.LogMigrationMessage(System.String[])')
  - [LogMigrationMessageLine(line,direction)](#M-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-LogMigrationMessageLine-System-String,System-String- 'AndcultureCode.CSharp.Data.SqlServer.Migrations.FlattenedMigration.LogMigrationMessageLine(System.String,System.String)')
  - [ValidateFlattenedShouldRun(id)](#M-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-ValidateFlattenedShouldRun-System-String- 'AndcultureCode.CSharp.Data.SqlServer.Migrations.FlattenedMigration.ValidateFlattenedShouldRun(System.String)')
- [IEnumerableExtensions](#T-AndcultureCode-CSharp-Data-SqlServer-Extensions-IEnumerableExtensions 'AndcultureCode.CSharp.Data.SqlServer.Extensions.IEnumerableExtensions')
  - [DistinctBy\`\`2(source,property)](#M-AndcultureCode-CSharp-Data-SqlServer-Extensions-IEnumerableExtensions-DistinctBy``2-System-Collections-Generic-IEnumerable{``0},System-Func{``0,``1}- 'AndcultureCode.CSharp.Data.SqlServer.Extensions.IEnumerableExtensions.DistinctBy``2(System.Collections.Generic.IEnumerable{``0},System.Func{``0,``1})')
  - [DistinctBy\`\`2(source,property)](#M-AndcultureCode-CSharp-Data-SqlServer-Extensions-IEnumerableExtensions-DistinctBy``2-System-Collections-Generic-List{``0},System-Func{``0,``1}- 'AndcultureCode.CSharp.Data.SqlServer.Extensions.IEnumerableExtensions.DistinctBy``2(System.Collections.Generic.List{``0},System.Func{``0,``1})')
- [Repository\`1](#T-AndcultureCode-CSharp-Data-SqlServer-Repositories-Repository`1 'AndcultureCode.CSharp.Data.SqlServer.Repositories.Repository`1')
  - [#ctor()](#M-AndcultureCode-CSharp-Data-SqlServer-Repositories-Repository`1-#ctor-AndcultureCode-CSharp-Core-Interfaces-IContext,Microsoft-Extensions-Localization-IStringLocalizer- 'AndcultureCode.CSharp.Data.SqlServer.Repositories.Repository`1.#ctor(AndcultureCode.CSharp.Core.Interfaces.IContext,Microsoft.Extensions.Localization.IStringLocalizer)')
  - [ERROR_DELETE_MISSING_ENTITY](#F-AndcultureCode-CSharp-Data-SqlServer-Repositories-Repository`1-ERROR_DELETE_MISSING_ENTITY 'AndcultureCode.CSharp.Data.SqlServer.Repositories.Repository`1.ERROR_DELETE_MISSING_ENTITY')
  - [ERROR_DELETE_SOFT_DELETION_NOT_IDELETEABLE](#F-AndcultureCode-CSharp-Data-SqlServer-Repositories-Repository`1-ERROR_DELETE_SOFT_DELETION_NOT_IDELETEABLE 'AndcultureCode.CSharp.Data.SqlServer.Repositories.Repository`1.ERROR_DELETE_SOFT_DELETION_NOT_IDELETEABLE')
- [SqlServerContext](#T-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext 'AndcultureCode.CSharp.Data.SqlServer.SqlServerContext')
  - [Add\`\`1(entity)](#M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-Add``1-``0- 'AndcultureCode.CSharp.Data.SqlServer.SqlServerContext.Add``1(``0)')
  - [ConfigureMappings()](#M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-ConfigureMappings-Microsoft-EntityFrameworkCore-ModelBuilder- 'AndcultureCode.CSharp.Data.SqlServer.SqlServerContext.ConfigureMappings(Microsoft.EntityFrameworkCore.ModelBuilder)')
  - [CreateStructure()](#M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-CreateStructure 'AndcultureCode.CSharp.Data.SqlServer.SqlServerContext.CreateStructure')
  - [Delete\`\`1(entity)](#M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-Delete``1-``0- 'AndcultureCode.CSharp.Data.SqlServer.SqlServerContext.Delete``1(``0)')
  - [DropStructure()](#M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-DropStructure 'AndcultureCode.CSharp.Data.SqlServer.SqlServerContext.DropStructure')
  - [GetEntityEntry\`\`1()](#M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-GetEntityEntry``1-``0- 'AndcultureCode.CSharp.Data.SqlServer.SqlServerContext.GetEntityEntry``1(``0)')
  - [Query\`\`1()](#M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-Query``1 'AndcultureCode.CSharp.Data.SqlServer.SqlServerContext.Query``1')
  - [SetAsAdded\`\`1()](#M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-SetAsAdded``1-``0- 'AndcultureCode.CSharp.Data.SqlServer.SqlServerContext.SetAsAdded``1(``0)')
  - [SetAsDeleted\`\`1()](#M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-SetAsDeleted``1-``0- 'AndcultureCode.CSharp.Data.SqlServer.SqlServerContext.SetAsDeleted``1(``0)')
  - [SetAsDetached\`\`1()](#M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-SetAsDetached``1-``0- 'AndcultureCode.CSharp.Data.SqlServer.SqlServerContext.SetAsDetached``1(``0)')
  - [SetAsModified\`\`1()](#M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-SetAsModified``1-``0- 'AndcultureCode.CSharp.Data.SqlServer.SqlServerContext.SetAsModified``1(``0)')
  - [UpdateEntityState\`\`1()](#M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-UpdateEntityState``1-``0,Microsoft-EntityFrameworkCore-EntityState- 'AndcultureCode.CSharp.Data.SqlServer.SqlServerContext.UpdateEntityState``1(``0,Microsoft.EntityFrameworkCore.EntityState)')
  - [Update\`\`1(entity)](#M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-Update``1-``0- 'AndcultureCode.CSharp.Data.SqlServer.SqlServerContext.Update``1(``0)')

<a name='T-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration'></a>
## FlattenedMigration `type`

##### Namespace

AndcultureCode.CSharp.Data.SqlServer.Migrations

##### Summary

Base class for migrations that have been flattened. Contains
helper methods to validate if the flattened migration should
run on a given database.

TODO: Tests should be written for this class at some point,
see Github issue here: https://github.com/AndcultureCode/AndcultureCode.CSharp.Data.SqlServer/issues/2

<a name='P-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-Context'></a>
### Context `property`

##### Summary

Should return the DbContext this migration works with. Recommend caching
the context, and instantiating a new one on first get if the cached
version has not yet been instantiated.

<a name='P-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-FlattenedMigrations'></a>
### FlattenedMigrations `property`

##### Summary

This should contain all flattened migration ID consts, in the order that they should
be run.

<a name='M-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-LogMigrationMessage-System-String[]-'></a>
### LogMigrationMessage(messages) `method`

##### Summary

Outputs a given list of messages to the console running the migration.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| messages | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') |  |

<a name='M-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-LogMigrationMessageLine-System-String,System-String-'></a>
### LogMigrationMessageLine(line,direction) `method`

##### Summary

Outputs a single message to the console running the migration, indicating the
direction of the migration.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| line | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| direction | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-ValidateFlattenedShouldRun-System-String-'></a>
### ValidateFlattenedShouldRun(id) `method`

##### Summary

This will check if, based on the sort order of the other migrations, this flattened
migration has not run on a fresh install.

##### Returns

True indicates the migration should be run. False indicates you should abort
running the migration, as this is not a fresh install, and the migration will likely fail.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The ID of the flattened migration, as defined in the FlattenedMigrations list. |

<a name='T-AndcultureCode-CSharp-Data-SqlServer-Extensions-IEnumerableExtensions'></a>
## IEnumerableExtensions `type`

##### Namespace

AndcultureCode.CSharp.Data.SqlServer.Extensions

<a name='M-AndcultureCode-CSharp-Data-SqlServer-Extensions-IEnumerableExtensions-DistinctBy``2-System-Collections-Generic-IEnumerable{``0},System-Func{``0,``1}-'></a>
### DistinctBy\`\`2(source,property) `method`

##### Summary

Returns a distinct enumerable by a specific property

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.IEnumerable{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{``0}') |  |
| property | [System.Func{\`\`0,\`\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |
| TKey |  |

<a name='M-AndcultureCode-CSharp-Data-SqlServer-Extensions-IEnumerableExtensions-DistinctBy``2-System-Collections-Generic-List{``0},System-Func{``0,``1}-'></a>
### DistinctBy\`\`2(source,property) `method`

##### Summary

Returns a distinct list by a specific property

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| source | [System.Collections.Generic.List{\`\`0}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.List 'System.Collections.Generic.List{``0}') |  |
| property | [System.Func{\`\`0,\`\`1}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``0,``1}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |
| TKey |  |

<a name='T-AndcultureCode-CSharp-Data-SqlServer-Repositories-Repository`1'></a>
## Repository\`1 `type`

##### Namespace

AndcultureCode.CSharp.Data.SqlServer.Repositories

##### Summary

SqlServer implementation for CRUD operations for `T`

<a name='M-AndcultureCode-CSharp-Data-SqlServer-Repositories-Repository`1-#ctor-AndcultureCode-CSharp-Core-Interfaces-IContext,Microsoft-Extensions-Localization-IStringLocalizer-'></a>
### #ctor() `constructor`

##### Summary

Default constructor injecting the data context

##### Parameters

This constructor has no parameters.

<a name='F-AndcultureCode-CSharp-Data-SqlServer-Repositories-Repository`1-ERROR_DELETE_MISSING_ENTITY'></a>
### ERROR_DELETE_MISSING_ENTITY `constants`

##### Summary

Entity could not be deleted as it does not exist

<a name='F-AndcultureCode-CSharp-Data-SqlServer-Repositories-Repository`1-ERROR_DELETE_SOFT_DELETION_NOT_IDELETEABLE'></a>
### ERROR_DELETE_SOFT_DELETION_NOT_IDELETEABLE `constants`

##### Summary

Entity cannot be soft deleted

<a name='T-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext'></a>
## SqlServerContext `type`

##### Namespace

AndcultureCode.CSharp.Data.SqlServer

##### Summary

Base implementation of a generic dbcontext

<a name='M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-Add``1-``0-'></a>
### Add\`\`1(entity) `method`

##### Summary

Gets the context ready for adding the entity, does not save the changes on the context

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| entity | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-ConfigureMappings-Microsoft-EntityFrameworkCore-ModelBuilder-'></a>
### ConfigureMappings() `method`

##### Summary

Configure the mappings for the context

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-CreateStructure'></a>
### CreateStructure() `method`

##### Summary

Bring the database up to the latest migration

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-Delete``1-``0-'></a>
### Delete\`\`1(entity) `method`

##### Summary

Gets the context ready for removing the entity, does not save the changes on the context

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| entity | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-DropStructure'></a>
### DropStructure() `method`

##### Summary

Remove all context items from the database

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-GetEntityEntry``1-``0-'></a>
### GetEntityEntry\`\`1() `method`

##### Summary

Get the entity entry

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-Query``1'></a>
### Query\`\`1() `method`

##### Summary



##### Returns



##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-SetAsAdded``1-``0-'></a>
### SetAsAdded\`\`1() `method`

##### Summary

Set the entity as being added

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-SetAsDeleted``1-``0-'></a>
### SetAsDeleted\`\`1() `method`

##### Summary

Set the entity as being deleted

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-SetAsDetached``1-``0-'></a>
### SetAsDetached\`\`1() `method`

##### Summary

Set the entity as detached

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-SetAsModified``1-``0-'></a>
### SetAsModified\`\`1() `method`

##### Summary

Set the entity as being modified

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-UpdateEntityState``1-``0,Microsoft-EntityFrameworkCore-EntityState-'></a>
### UpdateEntityState\`\`1() `method`

##### Summary

Update the entity state for the specified entity

##### Parameters

This method has no parameters.

<a name='M-AndcultureCode-CSharp-Data-SqlServer-SqlServerContext-Update``1-``0-'></a>
### Update\`\`1(entity) `method`

##### Summary

Gets the context ready for updating the entity, does not save the changes on the context

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| entity | [\`\`0](#T-``0 '``0') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |
