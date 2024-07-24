using BetterWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BetterWorld.Controllers
{
    public class Shared : Controller
    {
        BetterWorldDbContext db_context = new BetterWorldDbContext();
        public IActionResult Details(UserViewModel uvm)
        {
            var userName = User.Identity?.Name;
            var userew = db_context.Users.Where(x=> x.UserName == userName).FirstOrDefault();
            var mapped_user = new UserViewModel()
            {
                Id = userew.Id
            };
            return RedirectToAction("Details", "User", new { id = mapped_user.Id});


        }
    }
}
