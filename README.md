To use this repo you will first need to create a sql server database and then add your connection string to this layout in the user secrets:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=-----;Database=----;User Id=----;Password=----;TrustServerCertificate=True"
  }
}

Then you will need to follow these steps:

Step 1:
- Restore nuget packages

Step 2:
- Go to package manager console and run to add all migrations:
  - dotnet ef migrations script
    
- If this does not work you can add each migration manually using:
  - dotnet ef migrations script <migration name>

Step 3:
- To update the tables with the correct schema run:
  - dotnet ef database-update
