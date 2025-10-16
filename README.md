````md
# Bootcamp LMS Auth Backend

A foundational authentication and authorization API built with **ASP.NET Core**, **C#**, and **Microsoft SQL Server**. This service handles user registration, login, role-based access control, and token issuance for a Bootcamp Learning Management System.

---

## 📌 Overview

This backend service is a critical component of a modular LMS architecture. It focuses solely on **user identity**, **authentication**, and **authorization logic** — enabling secure access to different parts of the LMS based on user roles (e.g., Student, Instructor, Admin).

---

## 🔧 Tech Stack

| Layer       | Technology             |
|-------------|------------------------|
| Framework   | ASP.NET Core Web API   |
| Language    | C#                     |
| Database    | Microsoft SQL Server   |
| ORM         | Entity Framework Core  |
| Auth        | JWT (JSON Web Tokens)  |
| Config      | appsettings.json       |

---

## 📁 Project Structure

<pre>
bootcamp-lms-auth-be/
├── Controllers/           # API endpoints (e.g., AuthController)
├── DTOs/                  # Data Transfer Objects
├── DBContext/             # EF Core DbContext
├── Data/                  # Seed data and user entity
├── Enums/                 # User role definitions
├── Repositories/          # Interfaces and implementations for data access
├── Utils/                 # Helper classes (e.g., JWT generator, password hasher)
├── Migrations/            # EF Core database migrations
├── Program.cs             # Application startup and configuration
├── appsettings.json       # Main configuration file
└── lms-auth-be.sln        # Visual Studio solution file
</pre>

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK 6.0+](https://dotnet.microsoft.com/download)
- SQL Server or LocalDB
- (Optional) Postman or Swagger for testing

### Environment Configuration

Update `appsettings.Development.json` or `appsettings.json` with your local DB connection string and JWT settings:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BootcampLmsAuth;Trusted_Connection=True;"
  },
  "Jwt": {
    "Key": "YOUR_SECRET_KEY",
    "Issuer": "yourdomain.com",
    "Audience": "yourdomain.com",
    "ExpireMinutes": 60
  }
}
````

### Run the App

```bash
dotnet restore
dotnet ef database update
dotnet run
```

Open your browser or Postman and test via:
`https://localhost:5001/swagger` (if Swagger is enabled)

---

## 🔐 Authentication Features

* ✅ User registration (with password hashing)
* ✅ Login with JWT token issuance
* ✅ Role-based authorization (`Student`, `Instructor`, `Admin`)
* ✅ Secure route protection via policies
* ✅ Token generation and validation using utilities

---

## 🧪 Testing the API

Use Swagger, Postman, or the `lms-auth-be.http` file to test:

* `POST /api/auth/register`
* `POST /api/auth/login`
* `GET /api/user/profile` *(requires Bearer token)*
* Add token in headers to access protected routes.

---

## 🧭 Future Improvements

* 🔄 Refresh token support
* 📧 Email confirmation flow
* 🔐 Forgot password / reset password
* 🧪 Add unit and integration tests
* 🔍 Add Swagger UI with JWT auth
* 🐳 Add Dockerfile for container support
* 🚀 CI/CD pipeline integration
* 🛡 Rate limiting and brute-force protection

---

## 🤝 Contributors

Developed by:

* [@eubieald](https://github.com/eubieald)
* [@eWolf62095](https://github.com/eWolf62095)
* [@rchristianandrei](https://github.com/rchristianandrei)

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---

## 🙏 Acknowledgments

Created as part of a bootcamp capstone project to explore clean backend architecture and secure authentication practices using ASP.NET Core.
```
