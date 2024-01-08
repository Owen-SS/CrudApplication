This project has not been styled and is only for understanding the flow of data betweem the backend and the frontend.

To use this repo you will first need to create a sql server database and then add your connection string to this layout in the user secrets:

}
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


 To get the frontend working:
 
 Step 1: 
 -You need to create a .env file inside the CrudApplicationFrontend folder

 Step 2:
 - You need to define-
     -VITE_APP_ROOT_API

    forexample, if you are using local host it will look something like--
     VITE_APP_ROOT_API=https://localhost:44311/api/
   
Step 3:
  Once enviromental variables have been defined you should be able to run npm run dev to spin up a local frontend site

  KEY:
  .ENV(frontend) and USER SECRETS(Backend) should not be pushed up to the repository

 
