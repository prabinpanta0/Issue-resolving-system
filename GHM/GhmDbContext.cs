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
        public DbSet<GHM.Models.ModuleViewModel> ModuleViewModel { get; set; } = default!;
        public DbSet<GHM.Models.TeacherViewModel> TeacherViewModel { get; set; } = default!;
        public DbSet<GHM.Models.FeedbackQuestionViewModel> FeedbackQuestionViewModel { get; set; } = default!;
        public DbSet<GHM.Models.FeedbackViewModel> FeedbackViewModel { get; set; } = default!;
        public DbSet<GHM.Models.IssueViewModel> IssueViewModel { get; set; } = default!;
        public DbSet<GHM.Models.ResolvedIssuesViewModel> ResolvedIssuesViewModel { get; set; } = default!;
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

    public class FeedbackQuestion{
        public int Id { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public string Q4 { get; set; }
    }

    public class Feedback{
        public int Id { get; set; }
        public int ModuleId1 { get; set; }
        public int ModuleId2 { get; set; }
        public int ModuleId3 { get; set; }
        public int TeacherId1 { get; set; }
        public int TeacherId2 { get; set; }
        public int TeacherId3 { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int FeedbackQuestionId1 { get; set; }
        public Teacher Teacher1 { get; set; }
        public Teacher Teacher2 { get; set; }
        public Teacher Teacher3 { get; set; }
        public FeedbackQuestion FeedbackQuestion1 { get; set; }
        public FeedbackQuestion FeedbackQuestion2 { get; set; }
        public FeedbackQuestion FeedbackQuestion3 { get; set; }
        public FeedbackQuestion FeedbackQuestion4 { get; set; }


        // [ForeignKey("Module1")]
        // public int ModuleId1 { get; set; }

        // [ForeignKey("Module2")]
        // public int ModuleId2 { get; set; }

        // [ForeignKey("Module3")]
        // public int ModuleId3 { get; set; }

        // [ForeignKey("Teacher1")]
        // public int TeacherId1 { get; set; }

        // [ForeignKey("Teacher2")]
        // public int TeacherId2 { get; set; }

        // [ForeignKey("Teacher3")]
        // public int TeacherId3 { get; set; }
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
}
