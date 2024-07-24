using Microsoft.EntityFrameworkCore;
using BetterWorld.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BetterWorld
{
    public class BetterWorldDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<re> re { get; set; }
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
        public DbSet<BetterWorld.Models.UserProfileModel> UserProfileModel { get; set; } = default!;
        public DbSet<BetterWorld.Models.UserViewModel> UserViewModel { get; set; } = default!;
        public DbSet<BetterWorld.Models.review> review { get; set; } = default!;
    }

    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ContactNo { get; set; }
        public List<Job> Job = new();
    }




    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    public class Application
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] CV { get; set; }
        public string CVFileName { get; set; } // Add this line
        public string CVContentType { get; set; } // Add this line
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
    public class re
    {
        public int Id { get; set; }
        public int? Age { get; set; }
        public string Skills { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        //public byte[] Pic { get; set; }
        //public string PicFileName { get; set; } 
        //public string PicContentType { get; set; }
        public string PhoneNo { get; set; }
        public string Bio { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
