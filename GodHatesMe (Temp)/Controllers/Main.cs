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


        public ActionResult AddSemester()
        {
            return View();
        }

        // POST: Gotohell/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSemester(SemesterViewModel svm)
        {
            try
            {
                var entity = new Semester()
                {
                    Name = svm.Name,
                };
                db_context.Semesters.Add(entity);
                db_context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddIntake()
        {
            return View();
        }

        // POST: Gotohell/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddIntake(IntakeViewModel ivm)
        {
            try
            {
                var entity = new Intake()
                {
                    Name = ivm.Name,
                };
                db_context.Intakes.Add(entity);
                db_context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddProgram()
        {
            return View();
        }

        // POST: Gotohell/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProgram(ProgramViewModel pvm)
        {
            try
            {
                var entity = new Program()
                {
                    Name = pvm.Name,
                };
                db_context.Programs.Add(entity);
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


        public ActionResult AddQuestions()
        {
            return View();
        }

        // POST: Gotohell/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddQuestions(QuestionViewModel svm)
        {
            try
            {
                var entity = new Question()
                {
                    Text1 = svm.Text1,
                    Text2 = svm.Text2,
                    Text3 = svm.Text3,
                    Text4 = svm.Text4,
                    Text5 = svm.Text5,
                    Text6 = svm.Text6,
                    Text7 = svm.Text7,
                };
                db_context.Questions.Add(entity);
                db_context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Modules = db_context.Modules.Select(m => new ModuleViewModel
                {
                    Id = m.Id,
                    Name = m.Name
                }).ToList(),
                Semesters = db_context.Semesters.Select(s => new SemesterViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList(),
                Intakes = db_context.Intakes.Select(i => new IntakeViewModel
                {
                    Id = i.Id,
                    Name = i.Name
                }).ToList(),
                Programs = db_context.Programs.Select(p => new ProgramViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList(),
                Teachers = db_context.Teachers.Select(t => new TeacherViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    AverageScore = t.AverageScore,
                    ModuleId = t.ModuleId,
                    ModuleName = t.Module.Name // Assuming a navigation property for Module exists
                }).ToList(),
                Questions = db_context.Questions.Select(q => new QuestionViewModel
                {
                    Id = q.Id,
                    Text1 = q.Text1,
                    Text2 = q.Text2,
                    Text3 = q.Text3,
                    Text4 = q.Text4,
                    Text5 = q.Text5,
                    Text6 = q.Text6,
                    Text7 = q.Text7
                }).ToList()
            };

            return View(viewModel);
        }

    }
}
