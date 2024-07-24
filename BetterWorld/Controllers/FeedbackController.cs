using BetterWorld.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetterWorld.Controllers
{
    public class FeedbackController : Controller
    {
        BetterWorldDbContext db_context = new BetterWorldDbContext();
        // GET: FeedbackController
        public ActionResult Index(int CurrentPage = 1, int PageSize = 10)
        {
            var feel_list = db_context.Feedbacks
                .Select(x => new FeedbackViewModel()
                {
                    Id = x.Id,
                    Intake = x.Intake,
                    Program = x.Program,
                    Level = x.Level,
                    Semester = x.Semester,
                    Section = x.Section,
                });

            if (feel_list != null)
            {
                var paged_list = feel_list.OrderBy(x => x.Id)
                    .Skip((CurrentPage - 1) * PageSize)
                    .Take(PageSize).ToList();
                var new_list = new PaginatedFeedbackViewModel()
                {
                    Count = feel_list.Count(),
                    CurrentPage = CurrentPage,
                    PageSize = PageSize,
                    Data = paged_list
                };
                return View(new_list);
            }
            else
            {
                // Return a default view or an error view if feel_list is null
                return View(new PaginatedFeedbackViewModel()
                {
                    Count = 0,
                    CurrentPage = CurrentPage,
                    PageSize = PageSize,
                    Data = new List<FeedbackViewModel>()
                });
            }
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
