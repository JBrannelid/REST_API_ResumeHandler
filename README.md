# 📄 CV Handler REST API
![CV Handler ER Diagram](./asset/ResumeHandler_ER_Diagram.png)

## 📋 About the Project
This is a school project from Chas Academy's Fullstack .NET Developer program. The project is a REST API built with ASP.NET Core Minimal API that manages CV information including personal details, education history, and work experience.

## ✨ Core Features
- **Manage Personal Information**: Create, view, update, and delete personal details
- **Track Education History**: Record and manage education achievements
- **Document Work Experience**: Store professional experience information
- **GitHub Integration**: Retrieve public repository information for any GitHub username

Each person record includes:
- 👤 First and last name
- 📧 Email address
- 📱 Phone number
- 📝 Personal description

## 🛠️ Technologies
- ASP.NET Core Minimal API
- Entity Framework Core with **Code-First** approach
- SQL Server LocalDB
- External API integration (GitHub)

## 🔍 Error Handling
The API returns appropriate HTTP status codes:
- 200 OK - Successful operations
- 201 Created - New resource created
- 204 No Content - Successful deletion
- 400 Bad Request - Validation errors or invalid data
- 404 Not Found - Resource not found
- 500 Internal Server Error - Server-side issues

## 📂 Project Structure
- **Models**: Data models for Person, Education, Experience, and GitHub data
- **DTOs**: Data Transfer Objects for safe data transfer
- **Endpoints**: Minimal API endpoint definitions for each entity
- **Data**: DbContext for database connectivity with seeded test data

## 👨‍💻 Developed By
- Johannes Brannelid
- Student at Chas Academy
- Fullstack .NET Developer program 2024

## 📅 Course Information
- **Course**: Backend Development & API
- **School**: Chas Academy
