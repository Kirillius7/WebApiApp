# HumanWebApiApp


<img src="https://github.com/user-attachments/assets/ce23feed-8cea-4ed5-ac50-503f95db17e6" alt="Screenshot 1" width="800"/>
<img src="https://github.com/user-attachments/assets/bafad45c-2291-4d5e-a2bc-b1fd8ef4e481" alt="Screenshot 2" width="800"/>

# About the project
Human Management API is a RESTful Web API built with ASP.NET Core, designed to manage human entities with full CRUD functionality. The project demonstrates best practices in modern API development, including layered architecture, dependency injection, data validation, and structured error handling.

# Key Features

- **CRUD Operations:** Create, Read, Update, and Delete human records.
- **DTOs:** Data Transfer Objects for safe and clear data handling between layers.
- **Repository Pattern:** Encapsulates data access logic, keeping controllers clean.
- **Validation:** Server-side validation using Data Annotations to ensure data integrity.
- **Middleware:** Custom middleware for logging and centralized error handling.
- **Database Integration:** MySQL database connected via Entity Framework Core.
- **Logging:** Tracks actions and errors for easier debugging and monitoring.
- **Routing & Response Types:** Explicit routes and ProducesResponseType for clear API documentation.
- **Swagger:** API documentation and testing through Swagger UI.

# Technologies 
ASP.NET Core, C#, Entity Framework Core, MySQL, Swagger, Dependency Injection, Middleware, DTO pattern.

# Purpose:
This project showcases the ability to build a professional, maintainable, and scalable Web API, demonstrating practical knowledge of API architecture, error handling, validation, and database interaction. It also provides full data manipulation capabilities, allowing users to create, read, update, delete, and add records to the database.

# Getting Started:
## Installation:
- git clone https://github.com/Kirillius7/WebApiApp
- cd project
- dotnet restore
- dotnet build
- dotnet run
## Requests:
- GET https://localhost:7030/api/human/all - запит на виведення всіх людей із бази даних
- GET https://localhost:7030/api/human/1 - запит на виведення людини із бази даних за індексом
 
# Contacts
https://www.linkedin.com/in/kyrylo-popov-ab160536a/
