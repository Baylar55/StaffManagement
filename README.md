# Staff Management API

This project is a backend API built for managing employees, departments, and companies. It allows CRUD operations for employees, departments, and companies using ASP.NET Core 6.0 and MS SQL. The project follows Onion architecture and employs CQRS and the repository pattern.

## Technologies Used
- **.NET 6.0**
- **Entity Framework Core (Code First)**
- **MS SQL**
- **Swagger**
- **Onion Architecture**
- **CQRS & Mediator Pattern**

## Prerequisites
- .NET 6 SDK
- SQL Server (MS SQL)
- Visual Studio or any code editor supporting C#

## Getting Started

### 1. Clone the repository
```bash
git clone https://github.com/Baylar55/StaffManagement.git
cd StaffManagement
```
### 2. Set up the database

1. Ensure you have **SQL Server** installed and running.

2. Update the connection string, write your server name in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YourServerName;Database=StaffManagementDb;TrustServerCertificate=true;Trusted_Connection=true;"
}
```
3. Open your terminal in the project directory and navigate to API 
```bash
cd src/Presentation/StaffManagement.API/
```

4. Run migrations to create the database:
```bash
dotnet ef database update
```

### 3. Running the API
To run the application locally run below command in navigated directory (API):
```bash
dotnet run
```

### 4. Open Swagger UI
Once the application is running, you can access the API documentation through Swagger UI:
```
https://localhost:7180/swagger/index.html
```
