using Microsoft.EntityFrameworkCore;
using BetterWorld.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BetterWorld
{
    public class BetterWorldDbContext : DbContext
    {
        public DbSet<Module> Modules { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Intake> Intakes { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Score> Scores { get; set; }
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
    }

    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Program
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Semester
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Intake
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgramId { get; set; }
        public int IntakeId { get; set; }
        public int Level { get; set; }
        public int SemesterId { get; set; }
        public int Module1Id { get; set; }
        public int Module2Id { get; set; }
        public int Module3Id { get; set; }
        public int Module4Id { get; set; }

        public Program Program { get; set; }
        public Semester Semester { get; set; }
        public Intake Intake { get; set; }
        public Module Module1 { get; set; }
        public Module Module2 { get; set; }
        public Module Module3 { get; set; }
        public Module Module4 { get; set; }
    }

    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ModuleName { get; set; }
        public int AverageScore { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public string Text5 { get; set; }
        public string Text6 { get; set; }
        public string Text7 { get; set; }
    }

    public class Score
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int SectionId { get; set; }
        public int ModuleId { get; set; }
        public int ProgramId { get; set; }
        public int SemesterId { get; set; }
        public int Question1Score { get; set; }
        public int Question2Score { get; set; }
        public int Question3Score { get; set; }
        public int Question4Score { get; set; }
        public int Question5Score { get; set; }
        public int Question6Score { get; set; }
        public int Question7Score { get; set; }

        public int AverageScore { get; set; }

        public Semester Semester { get; set; }
        public Program Program { get; set; }
        public Module Module { get; set; }
        public Section Section { get; set; }
        public Teacher Teacher { get; set; }
    }



}
