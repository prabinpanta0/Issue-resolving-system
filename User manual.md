# User Manual: Setting Up the Team-1-Project

This manual will guide you through the steps required to set up the Team-1-Project from the GitHub repository.

## Prerequisites

Before you begin, ensure you have the following software installed on your machine:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/)
- [Git](https://git-scm.com/)

## Setup Instructions

### 1. Clone the Repository

Open a terminal and run the following command to clone the repository:

```bash
git clone https://github.com/siddhantbhattarai/Team-1-Project.git
```

### 2. Open the Project Folder

Navigate to the project folder:

```bash
cd Team-1-Project
cd GHM
```

### 3. Install .NET SDK and Other Dependencies

Ensure that you have the .NET SDK installed. You can download it from [here](https://dotnet.microsoft.com/download).

### 4. Open the Project in Visual Studio

- Launch Visual Studio.
- Open the project by selecting the `GHM.sln` solution file.

### 5. Restore NuGet Packages

Restore the necessary packages by running the following command in the terminal:

```bash
dotnet restore
```

Alternatively, you can restore packages from Visual Studio:

- Right-click on the solution in Solution Explorer.
- Select `Restore NuGet Packages`.

### 6. Update the Database

To ensure the database is up-to-date, use the Entity Framework (EF) Core migrations. Run the following command to apply any pending migrations and update the database:

```bash
dotnet ef database update
```

### 7. Run the Application

To run the application, use the following command:

```bash
dotnet run
```

Alternatively, you can start the application from Visual Studio:

- Press `F5` or click on the `Start` button.

### Database Configuration

The project uses a SQLite database configured in the `GhmDbContext` class. Here is an excerpt from the `GhmDbContext`:

```csharp
public class GhmDbContext : DbContext
{
    public DbSet<Module> Modules { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<FeedbackQuestion> FeedbackQuestions { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Issue> Issues { get; set; }
    public DbSet<ResolvedIssues> ResolvedIssues { get; set; }
    public string DbPath { get; }

    public GhmDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "jobportal.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}
```

The database file `jobportal.db` is stored in the local application data folder.

### Additional Notes

- Ensure your .NET SDK and Visual Studio are up-to-date to avoid compatibility issues.
- If you encounter any issues, refer to the project's GitHub repository for any updates or issues raised by other users.

By following these steps, you should be able to set up and run the Team-1-Project successfully. If you have any questions or need further assistance, feel free to refer to the project's documentation or raise an issue on GitHub.
