# Buddha.NET
### The meditative Mediator framework for C# and ASP.NET Core

Structure
------
- Buddha.NET/ - Main project (class library) containing the implementation
- Buddha.NET.AspNetCore/ - Tools for using Buddha.NET with ASP.NET Core (currently only convenience, BuddhaController)
- Buddha.NET.Demo/ - Demo ASP.NET Core Web API project implementing the Mediator pattern with Buddha.NET

Usage
------
As an example we will create a new ASP.NET Core Web API project (with .NET 5).
If you want to see or get the full demo project immediately, look at the "Buddha.NET.Demo/" folder. 

1. Create a new C# project, add Buddha.NET (and Buddha.NET.AspNetCore if needed) as dependencies
2. Remove the default files (in ASP.NET Core for example: "WeatherForecast.cs" and "WeatherForecastController.cs")
3. Create Buddha.NET folder structure, we use the following as an example:
    - Model/ - Here are your entities.
    - Actions/ - Here you add the Mediator actions as sub-folders (eg. GetTodos) and inside them the Request, Response, Command and (if needed) Validator files.
    - Controllers/ - Here you add your Controllers.
    - Services/ - Here you add any needed services (for CRUD, DB operations, etc.)

4. Create your first API endpoint (we use "/api/Todos/GetTodos" as an example)
   1. Add a new folder inside "Actions/" called "GetTodos"
   2. Inside "Actions/GetTodos/" add "GetTodosRequest.cs", "GetTodosResponse.cs", "GetTodosCommand.cs"
   3. Inside "Controllers/" add a new empty API controller called "TodosController.cs", let it inherit from "BuddhaController" (base class) and create an empty constructor
   
**__Under construction__**


Future
------
I will enhance this project further down the line (happy to get comments and issues posted).

Planned:
- Publish as a package on NuGet
- Write unit tests