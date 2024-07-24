using BetterWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BetterWorld.Controllers
{
    public class SearchController : Controller
    {
        BetterWorldDbContext _context = new BetterWorldDbContext();

        public IActionResult Index(string searchTerm)
        {

            ViewBag.CurrentFilter = searchTerm; // Set ViewBag.CurrentFilter

            var viewModel = new SearchViewModel
            {
                SearchTerm = searchTerm
            };


            if (!string.IsNullOrEmpty(searchTerm))
            {
                viewModel.Organizations = _context.Organizations
                    .Where(o => EF.Functions.Like(o.Name, $"%{searchTerm}%") || EF.Functions.Like(o.Address, $"%{searchTerm}%"))
                    .ToList();

                viewModel.Jobs = _context.Jobs
                    .Include(j => j.Organization)
                    .Where(j => EF.Functions.Like(j.Title, $"%{searchTerm}%") || EF.Functions.Like(j.Description, $"%{searchTerm}%") || EF.Functions.Like(j.Organization.Name, $"%{searchTerm}%"))
                    .ToList();

                viewModel.Applications = _context.Application
                    .Include(a => a.User)
                    .Include(a => a.Job)
                    .ThenInclude(j => j.Organization)
                    .Where(a =>  EF.Functions.Like(a.Email, $"%{searchTerm}%") || EF.Functions.Like(a.Job.Title, $"%{searchTerm}%") || EF.Functions.Like(a.Job.Organization.Name, $"%{searchTerm}%") || EF.Functions.Like(a.User.UserName, $"%{searchTerm}%"))
                    .ToList();
            }

            return View(viewModel);
        }
    }

    public class SearchViewModel
    {
        public string SearchTerm { get; set; }
        public List<Organization> Organizations { get; set; }
        public List<Job> Jobs { get; set; }
        public List<Application> Applications { get; set; }

        public SearchViewModel()
        {
            Organizations = new List<Organization>();
            Jobs = new List<Job>();
            Applications = new List<Application>();
        }
    }
}