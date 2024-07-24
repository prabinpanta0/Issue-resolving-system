using Humanizer;
using BetterWorld.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Diagnostics;

namespace BetterWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


//1.Command to create a new project named 'JobPortal' inside a folder JobPortal
//--> dotnet new mvc - o JobPortal
//2.The code command opens the JobPortalproject folder in the current instance of Visual Studio Code.
//--> code -r JobPortal
//3.Run this command to allow http certificates in case needed 
//--> dotnet dev-certs https --trust
//4. Run this command to run the web application 
// --> dotnet run
