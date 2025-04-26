# **🐞 Bug Ticketing System**
## **Description**
A backend API system built with ASP.NET Core using Clean 3-Layer Architecture to manage software bug tracking and resolution.
The system includes features like user authentication and authorization, project management, bug reporting and assignment, file attachments, and user-bug relationships.

💡 This project is based on a real-world Bug Tracking workflow to help teams manage software issues effectively and improve collaboration.

![005](https://github.com/user-attachments/assets/5a95aa05-2af6-4079-8966-87b09aa9feb9)


# 🏗️ Tech Stack
-Language: C#

-Framework: ASP.NET Core Web API

-AutoMapper

-Database: SQL Server

-Architecture: Clean Architecture

-Authentication: ASP.NET Identity + JWT (Access & Refresh Tokens)

-Authorization: Role-based

-File Upload: Image service

-Swagger (for API documentation)



# **📦 API Endpoints**
   Project
  ![000003](https://github.com/user-attachments/assets/a4018e00-71cf-41b6-8cc1-39d45a67e28d)
  
  Bug
  ![0002](https://github.com/user-attachments/assets/3aa6c177-dd60-4224-8948-1928b2695327)

  Attachments
  ![01](https://github.com/user-attachments/assets/46f971bd-2ff2-4e92-9cfb-e053cbd6cd12)

  User:
  ![004](https://github.com/user-attachments/assets/2a0f9581-90a7-4202-b619-3f72c17a80d3)

## 📂 Project Structure

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


