# Web Apis

## DB Migrations

Generate new EF Core migration files by running the following command from the project root folder (where the WebApi.csproj file is located), these migrations will create the database and tables for the .NET Core API.

`dotnet ef migrations add InitialCreate`

## Run Migrations

Run the follwoing command from the project root folder to execute the EF Core migrations and create the database and tables in SQL Server. Check SQL Server and you should now see your database with the tables Users and __EFMigrationsHistory.

`dotnet ef database update`