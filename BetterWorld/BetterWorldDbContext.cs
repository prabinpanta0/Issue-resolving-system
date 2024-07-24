using Microsoft.EntityFrameworkCore;
using BetterWorld.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BetterWorld
{
    public class BetterWorldDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public string DbPath { get; }
        public BetterWorldDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "jobportal_Ed1.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        // use this command to download SqlLite :dotnet add package Microsoft.EntityFrameworkCore.Sqlite
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
        public DbSet<BetterWorld.Models.FeedbackViewModel> FeedbackViewModels { get; set; } = default!;
    }

    public class Feedback
    {
        public int Id { get; set; }
        public string Program { get; set; }
        public string Intake { get; set; }
        public string Level { get; set; }
        public string Section { get; set; }
        public string Semester { get; set; }
        public string Points { get; set; }
        public string Tutor { get; set; }
        public string Module { get; set; }
        public string Misc { get; set; }
    }
}
