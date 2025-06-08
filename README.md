# EduHome

EduHome is a web application built with ASP.NET Core Razor Pages targeting .NET 7. It provides a modern, scalable foundation for educational or informational websites.

## Features

- Built with ASP.NET Core Razor Pages (.NET 7)
- Configurable database connection via `appsettings.json`
- Structured logging and environment configuration

## Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- SQL Server (or compatible database)

### Setup

1. **Clone the repository:**
2. **Configure the database connection:**
- Open `appsettings.json`.
- Update the `Default` connection string under `ConnectionStrings` with your server and database details:
  ```json
  "ConnectionStrings": {
    "Default": "Server=YourServerNameHere; Initial Catalog=YourDatabaseNameHere; Trusted_Connection=SSPI; Encrypt=false; TrustServerCertificate=true"
  }
  ```

3. **Restore dependencies and run the application:**
4. **Access the application:**
- Navigate to `https://localhost:5001` (or the URL specified in the output).

## Configuration

- **Logging:** Adjust log levels in `appsettings.json` under the `Logging` section.
- **Allowed Hosts:** Configure allowed hosts using the `AllowedHosts` setting.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.
