# TaxPayer-Calculator-Test
It's a simple ASP .NET Core + ReactJS application to calculate the net salary for a brazilian worker.

## Steps to run the application

1. This project was made using Visual Studio 2019 and SQL Server.


2. Configure the `appsettings.json` to use the correct Connection string to access the Database, your `appsettings` must be like this:
```
"ConnectionStrings": {
  "DefaultConnection": "Server={HOST};Database=TaxPayer;User={USER};Password={PASSWORD};MultipleActiveResultSets=true;"
}
```


3. Create the Database and Tables using the SQL script `db` inside `Database/sql`.


3. Run it!
