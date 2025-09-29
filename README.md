# Employee Management Backend

This is the backend API for an **Employee Management System**, which provides endpoints to manage employee records (create, read, update, delete).  

The project also implements **CQRS (Command Query Responsibility Segregation)** and **MediatR** for better database and API management, ensuring clean separation of concerns, maintainability, and scalability.

## Table of Contents

- [Features](#features)  
- [Tech Stack](#tech-stack)  
- [Getting Started](#getting-started)  
  - [Prerequisites](#prerequisites)  
  - [Installation](#installation)  
  - [Configuration](#configuration)  
  - [Running the Application](#running-the-application)  
- [API Endpoints](#api-endpoints)  
- [Data Model](#data-model)  
- [Error Handling](#error-handling)  
- [Testing](#testing)  
- [Future Improvements](#future-improvements)  
- [License](#license)  

---

## Features

- CRUD operations for employee records (Create, Read, Update, Delete)  
- Fetch all employees  
- Fetch single employee by ID  
- Update existing employee data  
- Delete single employee  
- Delete all employees  
- Structured project layers (Controllers, Models, etc.)  
- Implemented **CQRS** pattern with **MediatR** for clean separation of queries and commands  

---

## Tech Stack

List of major technologies and frameworks used in this project:

| Layer | Technology / Library |
|---|---|
| Framework / API | .NET / C# / ASP.NET Core Web API |
| Design Pattern | CQRS (Command Query Responsibility Segregation) |
| Mediator Pattern | MediatR |
| Data Access / ORM | (e.g. Entity Framework Core, Dapper, ADO.NET) |
| Database | (e.g. SQL Server, MySQL, PostgreSQL, etc.) |
| Configuration | appsettings.json, environment variables |
| Testing | (if applicable: xUnit, NUnit, etc.) |
| Tools | Postman (for manual API testing) |

---

## Getting Started

### Prerequisites

Before you begin, ensure you have the following installed:

- .NET SDK (version compatible with the project)  
- A relational database (SQL Server, MySQL, etc.)  
- (Optional) A tool to manage the database (SSMS, MySQL Workbench, etc.)  
- (Optional) Postman or another API client  

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/salmansaymon57/employee-management-backend.git
   cd employee-management-backend
   ```

2. **Restore dependencies**

   ```bash
   dotnet restore
   ```

3. **Set up the database**

   - Create a new database (e.g. `EmployeeDb`) in your DB server  
   - Apply migrations (if using EF Core) or run SQL scripts to create the `Employees` table etc.

### Configuration

1. Open `appsettings.json` (and optionally `appsettings.Development.json`)  
2. Update the connection string to point to your database  
3. (Optional) Add any secrets or settings (e.g. JWT secret, logging settings)  

Example `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EmployeeDb;User Id=sa;Password=Your_password;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

### Running the Application

To run locally:

```bash
dotnet run
```

By default, the API might start on `https://localhost:5001` or `http://localhost:5000` (depending on launch settings).  

You can test the endpoints via Postman, cURL, or any HTTP client.

---

## API Endpoints

Below is an example of the REST API endpoints. Adjust according to your actual controllers:

| Method | Route | Description | Request Body | Response |
|---|---|---|---|---|
| GET | `/api/employees` | Get all employees | — | List of employees |
| GET | `/api/employees/{id}` | Get a single employee by ID | — | Employee object |
| POST | `/api/employees` | Create a new employee | JSON of employee data (e.g. name, email, etc.) | Created employee |
| PUT | `/api/employees/{id}` | Update an existing employee | JSON of updated fields | Updated employee |
| DELETE | `/api/employees/{id}` | Delete an employee by ID | — | No content / confirmation |


### Example Request & Response

**Request (POST /api/employees):**

```json
{
  "name": "John Doe",
  "email": "john.doe@example.com",
  "department": "Engineering",
  "salary": 50000
}
```

**Response (201 Created):**

```json
{
  "id": 1,
  "name": "John Doe",
  "email": "john.doe@example.com",
  "department": "Engineering",
  "salary": 50000
}
```

---

## Data Model

Here is an example of what the Employee model might look like (adjust based on your actual code):

```csharp
public class Employee
{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int employeeId { get; set; }
        [Required]
        [MaxLength(50)]
        public String? firstName { get; set; }
        [Required]
        [MaxLength(50)]
        public String? lastName { get; set; }
        public String? email { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public String? contactNo { get; set; }
        public String? city { get; set; }
        public String? address { get; set; }
}
```

If you use EF Core, you might also have a `DbContext`:

```csharp
public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}
```

---

## Error Handling

- The API should return appropriate HTTP status codes (e.g. `400 Bad Request`, `404 Not Found`, `500 Internal Server Error`)  
- Use meaningful error messages in the response body  
- (Optional) Use a global exception handler / middleware to catch unhandled exceptions  

---

## Testing

If you have unit / integration tests, describe how to run them:

```bash
dotnet test
```

You can also manually test endpoints using Postman or cURL.

---

## Future Improvements

- Add authentication & authorization (e.g. JWT)  
- Add paging, filtering, sorting for list endpoints  
- Add input validation (e.g. FluentValidation)  
- Add logging & monitoring  
- Add more detailed audit trails (created/updated timestamps)  
- Add versioning to the API  
- Add more entity relationships (departments, roles)  
- Extend CQRS with more queries/commands for scalability  

---



## Acknowledgments

- Inspired by standard CRUD API patterns  
- Uses **CQRS + MediatR** for clean architecture and better API/database management  
- Any libraries, tooling, or tutorials you followed  

