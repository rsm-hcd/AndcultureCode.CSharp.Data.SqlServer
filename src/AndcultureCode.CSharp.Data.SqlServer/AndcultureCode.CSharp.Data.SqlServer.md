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
