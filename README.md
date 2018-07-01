# netcore2.1-pg10
PoC to try to use PostGresql with .NET Core 2.1.

## Prerequisite
 - [.NET Core 2.1 SDK](https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300)
## Steps to Reproduce
 1. Create an ASP.NET Core 2.1 MVC Web Project in Visual Studio
 2. Change Authentication to allow support for Individual User Accounts
 3. Create Models
 4. Add DbSet of Models to ApplicationDbContext
 5. Add NuGet packages for Npgsql
 6. Change service in startup to use Npgsql instead of SQL Server
 7. Generate Controller for Foos
 8. Modify POST controller in Foos
 9. Add connection string to appsettings.json
 10. Run "Add-Migration InitialCreate" in NuGet Package Console
 11. Run "Update-Database" in NuGet Package Console
 
### Notes
 - Secret Manager stores secret for DbPassword. The password is not encrypted.
