<a name='assembly'></a>
# AndcultureCode.CSharp.Data.SqlServer

## Contents

- [FlattenedMigration](#T-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration 'AndcultureCode.CSharp.Data.SqlServer.Migrations.FlattenedMigration')
  - [Context](#P-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-Context 'AndcultureCode.CSharp.Data.SqlServer.Migrations.FlattenedMigration.Context')
  - [FlattenedMigrations](#P-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-FlattenedMigrations 'AndcultureCode.CSharp.Data.SqlServer.Migrations.FlattenedMigration.FlattenedMigrations')
  - [LogMigrationMessage(messages)](#M-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-LogMigrationMessage-System-String[]- 'AndcultureCode.CSharp.Data.SqlServer.Migrations.FlattenedMigration.LogMigrationMessage(System.String[])')
  - [LogMigrationMessageLine(line,direction)](#M-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-LogMigrationMessageLine-System-String,System-String- 'AndcultureCode.CSharp.Data.SqlServer.Migrations.FlattenedMigration.LogMigrationMessageLine(System.String,System.String)')
  - [ValidateFlattenedShouldRun(id)](#M-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration-ValidateFlattenedShouldRun-System-String- 'AndcultureCode.CSharp.Data.SqlServer.Migrations.FlattenedMigration.ValidateFlattenedShouldRun(System.String)')

<a name='T-AndcultureCode-CSharp-Data-SqlServer-Migrations-FlattenedMigration'></a>
## FlattenedMigration `type`

##### Namespace

AndcultureCode.CSharp.Data.SqlServer.Migrations

##### Summary

Base class for migrations that have been flattened. Contains
helper methods to validate if the flattened migration should
run on a given database.

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
