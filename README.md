# Dream Reserve Backend

Dream Reserve is a website that allows you to make personalized reservations for your stay and tours in the city of Medellin. This is the backend repository for the collaborative project.

- [Frontend Repository](https://github.com/carobte/Dream-Reserve-front)
- [API](https://dream-reserve.azurewebsites.net/swagger/index.html)
- [Web](https://dream-reserve.vercel.app/)

## Content

1. [Project](#project)
2. [Development](#development-mode)
3. [Endpoints API](Endpoints.md)


## Project

### Why?

A need was identified regarding the ways to book and promote tourism in Medellín. Currently, users do not have the ability to personalize their trips when booking different activities, flights, and hotels. This is where Dream Reserve comes in—to offer users the opportunity to customize each component of their trip to meet their specific needs and desires, making their experience more rewarding.

### Purpose

 Dream Reserve is designed to give users the ability to personalize every detail of their trip, allowing them better control over their expenses and, consequently, their experience while touring the city of Medellín.

### Target Audience

 For all individuals who wish to engage in tourism in the city of Medellín, Colombia.

### Chosen Theme: 
Tourism

### Authors: 

- [Camilo Barreneche](https://www.github.com/camilobarre)
- [Carolina Bustamante](https://www.github.com/carobte)
- [Camilo Campillo](https://www.github.com/J-CamiloG)
- [Valeria Piedrahita](https://www.github.com/valeria2508)
- [Santiago Pineda](https://www.github.com/santiagopt97)
- [David Sánchez](https://www.github.com/deilons)

## Development 

### Prerequisites

Make sure you have the following installed before getting started:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- [MySQL](https://www.mysql.com/) (version 8.0 or higher)
- [Git](https://git-scm.com/)

<hr>

### To clone this repository:

- <code> Git clone https://github.com/carobte/Dream-Reserve-Backend </code>

<hr>

### To restore dependencies

Restore NuGet packages:

- <code> dotnet restore </code>

<hr>

### .env file

Make sure you add the environment variables locally in the .env file:

DB_HOST =  </br>
DB_PORT =  </br>
DB_DATABASE = </br>
DB_USERNAME = </br>
DB_PASSWORD = </br>
</br>
JWT_KEY = </br> 
JWT_ISSUER = </br>
JWT_AUDIENCE = </br>
JWT_EXPIREMINUTES = </br>

<hr>

### To run the project in dev mode

- <code> dotnet run </code>

Note: Remember to add the /swagger to your localhost so you can see the available endpoints.

<hr>

### NuGet Packages Used

- **Entity Framework Core**: for object-relational mapping (ORM)
- **Entity Framework Core Tools**: for running EF Core commands in the CLI
- **Entity Framework Core Design**: for scaffolding and other design-time features in EF Core
- **Pomelo EntityFrameworkCore MySql**: for MySQL database support in Entity Framework Core
- **DotNetEnv**: for loading environment variables from a `.env` file
- **Authentication JwtBearer**: for authentication middleware - JSON Web Tokens (JWT) in ASP.NET Core for the API. 
- **Swashbuckle AspNetCore**: for API documentation with Swagger in ASP.NET Core projects.