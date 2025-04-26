//🐞 Bug Ticketing System
A backend API system built with ASP.NET Core using Clean 3-Layer Architecture to manage software bug tracking and resolution.
The system includes features like user authentication and authorization, project management, bug reporting and assignment, file attachments, and user-bug relationships.

💡 This project is based on a real-world Bug Tracking workflow to help teams manage software issues effectively and improve collaboration.



🏗️ Tech Stack
-Language: C#
-Framework: ASP.NET Core Web API
- AutoMapper 
-Database: SQL Server
-Architecture: Clean Architecture
-Authentication: ASP.NET Identity + JWT (Access & Refresh Tokens)
-Authorization: Role-based
-File Upload: Image service
- Swagger (for API documentation)

📦 API Endpoints
  Project:
  Bug:
  Attachments:
  User:
  
📂 Project Structure

/Project.Api
    ├── Base
    ├── Controllers
    ├── appsettings.json
    └── Program.cs

/Bug Ticketing.BL
    ├── DTOS
    ├── Managers
    └── BusinessExtensions.cs

/Bug Ticketing.DAL
    ├── Context
    ├── GenericRepository
    ├── Migrations
    ├── Repositories
    ├──  UnitOfWork
    └── DataAccesExtensions.cs


