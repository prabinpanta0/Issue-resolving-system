using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GodHatesMe.Controllers
{
    public class Gotohell : Controller
    {
        // GET: Gotohell
        public ActionResult Index()
        {
            return View();
        }

        // GET: Gotohell/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Gotohell/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gotohell/Create
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

        // GET: Gotohell/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Gotohell/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Gotohell/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Gotohell/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
