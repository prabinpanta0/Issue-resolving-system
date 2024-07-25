//Controller to return View For Dashboard page

using Microsoft.AspNetCore.Mvc;

namespace GHM.Controllers{
    public class Dashboard : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}