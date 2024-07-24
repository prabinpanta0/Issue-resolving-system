using GodHatesMe.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace GodHatesMe.Controllers
{
    public class Main : Controller
    {
       GodHatesMeDbContext db_context = new GodHatesMeDbContext();


        public ActionResult AddModule()
        {
            return View();
        }

        // POST: Gotohell/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddModule(ModuleViewModel mvm)
        {
            try
            {
                var entity = new Module()
                {

                    Name = mvm.Name,
 
                };
                db_context.Modules.Add(entity);
                db_context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult AddTeacher()
        {
            var moduleList = db_context.Modules.Select(x => new ModuleViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            ViewBag.Modules = moduleList;
            return View();
        }

        // POST: AddTeacher
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTeacher(TeacherViewModel tvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = new Teacher()
                    {
                        AverageScore = tvm.AverageScore,
                        Name = tvm.Name,
                        ModuleId = tvm.ModuleId,
                    };
                    db_context.Teachers.Add(entity);
                    db_context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                // Log the error (uncomment the line below once you have a logging framework in place)
                // Log.Error(ex, "Error adding teacher");
            }

            // If we got this far, something failed, redisplay form
            var moduleList = db_context.Modules.Select(x => new ModuleViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            ViewBag.Modules = moduleList;
            return View(tvm);
        }


    }
}
