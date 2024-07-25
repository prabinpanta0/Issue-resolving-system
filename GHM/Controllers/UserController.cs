using GHM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GHM.Controllers

{
   public class UserContoller: Microsoft.AspNetCore.Mvc.Controller
    {
        GhmDbContext db = new GhmDbContext();
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
   }
}