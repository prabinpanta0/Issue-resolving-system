using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetterWorld.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: FeedbackController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FeedbackController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FeedbackController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeedbackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

 
    }
}
