# Web Apis

## Run API

Run project by using following command
`dotnet run`


## NUGET Packages

The dotnet list package command provides a convenienet option to list all NuGet package references for a specific project or a solution.

`dotnet list package`
## DB Migrations

Generate new EF Core migration files by running the following command from the project root folder (where the WebApi.csproj file is located), these migrations will create the database and tables for the .NET Core API.

`dotnet ef migrations add InitialCreate`

## DB Migrations in specified folder

`dotnet ef migrations add InitialCreate -o ./Data/Migrations`
## Run Migrations

Run the follwoing command from the project root folder to execute the EF Core migrations and create the database and tables in SQL Server. Check SQL Server and you should now see your database with the tables Users and __EFMigrationsHistory.

`dotnet ef database update`

Drop database

`dotnet ef database drop`