# Company Management Solution (.NET 8)

This repository contains a multi-layered .NET 8 solution for company management, following best practices with a clear separation of concerns:

- **DAL** (Data Access Layer): Handles database operations using Entity Framework Core and SQL Server.
- **BLL** (Business Logic Layer): Contains business logic and service classes.
- **CompanyManagement**: The main application (likely a WPF or console app) that interacts with users and orchestrates operations.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 or later (recommended)
- SQL Server (local or remote instance)

## Getting Started

1. **Clone the repository:**
   git clone https://github.com/yourusername/your-repo-name.git cd your-repo-name
2. **Restore NuGet packages:**
   dotnet restore
3. **Configure the database connection:**
   - Edit the `appsettings.json` (typically in the DAL or main app project) to set your SQL Server connection string.
  
4. **Apply Entity Framework migrations (if needed):**
   - dotnet ef database update --project DAL
5. **Build and run the solution:**
   - Open the solution in Visual Studio and press F5, or use:
     + dotnet build
     + dotnet run --project CompanyManagement
## Project Structure

- `DAL/`  
  Data access logic, Entity Framework Core context, and repositories.

- `BLL/`  
  Business logic, services, and domain rules.

- `CompanyManagement/`  
  Main application (UI or entry point).

## Usage

- Reference the DAL and BLL projects in your main application.
- Use dependency injection to access services and repositories.
- Update configuration files as needed for your environment.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License.

---

**Note:**  
Replace `yourusername/your-repo-name` with your actual GitHub repository path.  
Add more details about each project or specific setup steps as your solution evolves.
