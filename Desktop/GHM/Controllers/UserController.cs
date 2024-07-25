using GHM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GHM.Controllers

{
   public class UserContoller: Controller{
        public IActionResult Index()
        {
            return View();
        }
   }
}