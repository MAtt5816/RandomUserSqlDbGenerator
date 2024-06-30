# How to run?

[Bulid project](#build-project) or [use Docker image](#use-docker-image).

## Build project

> Note: This method is intended for Windows and may vary from Linux (paths, extensions, etc.).

1. Compile solution:
   ```shell
   dotnet build RandomUserSqlDbGenerator.sln -c Release
   ```
2. Run application:
   ```shell
   bin/Release/net8.0/RandomUserSqlDbGenerator.exe 1000 > db.sql
   ```
   where `1000` is a number of users to generate (**must be greater than 0**) and `db.sql` is name of output SQL file.

## Use Docker image

Run:

```csharp
docker run --rm ghcr.io/matt5816/random-user-sql-db-generator:latest 1000 > db.sql
```
where `1000` is a number of users to generate (**must be greater than 0**) and `db.sql` is name of output SQL file.
