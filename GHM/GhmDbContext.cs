using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite; // Add this using directive
using GHM.Models;

namespace GHM
{
    public class GhmDbContext : DbContext
    {
        public DbSet<Module> Modules { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<FeedbackQuestion> FeedbackQuestions { get; set; }
        // public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<ResolvedIssues> ResolvedIssues { get; set; }
        // public DbSet<User> Users { get; set; }
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
        // public DbSet<GHM.Models.ModuleViewModel> ModuleViewModel { get; set; } = default!;
        // public DbSet<GHM.Models.TeacherViewModel> TeacherViewModel { get; set; } = default!;
        // public DbSet<GHM.Models.FeedbackQuestionViewModel> FeedbackQuestionViewModel { get; set; } = default!;
        // public DbSet<GHM.Models.FeedbackViewModel> FeedbackViewModel { get; set; } = default!;
        // public DbSet<GHM.Models.IssueViewModel> IssueViewModel { get; set; } = default!;
        // public DbSet<GHM.Models.ResolvedIssuesViewModel> ResolvedIssuesViewModel { get; set; } = default!;
        // public DbSet<GHM.Models.UserViewModel> UserViewModel { get; set; } = default!;
    }

    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Teacher{
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }

    }

    public class FeedbackQuestion
    {
        public int Id { get; set; }
        public string Qn { get; set; }
    }




    public class Issue{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string RecommendedSolution { get; set; }
    }

    public class ResolvedIssues{
        public int Id {get; set;}
        public int IssueId {get; set;}
        public string Status {get; set;} = "Pending";
        public Issue Issue {get; set;}
    }

    // public class User
    // {
    //     public int Id { get; set; }
    //     public string Name { get; set; }

    //     public string Password { get; set; }
    //     public string Role { get; set; }
    // }
}
