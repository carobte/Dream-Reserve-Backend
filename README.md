# Dream Reserve Backend

Dream Reserve is a website that allows you to make personalized reservations for your stay and tours in the city of Medellin. This is the backend repository for the collaborative project.

## Prerequisites

Make sure you have the following installed before getting started:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- [MySQL](https://www.mysql.com/) (version 8.0 or higher)
- [Git](https://git-scm.com/)

## To clone this repository:

- <code> Git clone https://github.com/carobte/Dream-Reserve-Backend </code>

## To install dependencies

Restore NuGet packages:

 <code> dotnet restore </code>

## To run the project in dev mode

- <code> dotnet run </code>

Note: Remember to add the /swagger to your localhost so you can see the available endpoints.


## NuGet Packages Used

- **Entity Framework Core**: for object-relational mapping (ORM)
- **Entity Framework Core Tools**: for running EF Core commands in the CLI
- **Entity Framework Core Design**: for scaffolding and other design-time features in EF Core
- **Pomelo EntityFrameworkCore MySql**: for MySQL database support in Entity Framework Core
- **DotNetEnv**: for loading environment variables from a `.env` file