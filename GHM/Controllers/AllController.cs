using GHM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using Microsoft.AspNetCore.Mvc;


namespace GHM.Controllers
{
    public class All : Microsoft.AspNetCore.Mvc.Controller
    {
        GhmDbContext db = new GhmDbContext();

        /// Controller For Module Creatation
        /// 
        public IActionResult CreateModule()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateModule(ModuleViewModel module)
        {
            try{
                var mod = new Module()
                {
                    Name = module.Name
                };
                db.Modules.Add(mod);
                db.SaveChanges();
                return RedirectToAction("ModuleList");
            }
            catch{
                return View();
            }
        }
       
       /// Controller For Teacher Creatation
        /// 
        public IActionResult CreateTeacher()
        {
            ///show Module list
            /// for the user to select the module in teacher creation
            var modules = db.Modules.Select(m => new ModuleViewModel
            {
                Id = m.Id,
                Name = m.Name
            }).ToList();

            ViewBag.Module = modules;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTeacher(TeacherViewModel teacher)
        {
            try{
                var teach = new Teacher()
                {
                    Name = teacher.Name,
                    ModuleId = teacher.ModuleId
                };
                db.Teachers.Add(teach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch{
                return View();
            }
        }

   // Controller for creating Feedback Questions
    public IActionResult CreateFeedbackQuestion()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateFeedbackQuestion(FeedbackQuestionViewModel feedbackQuestion)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var questions = new List<string> { feedbackQuestion.Q1, feedbackQuestion.Q2, feedbackQuestion.Q3, feedbackQuestion.Q4 };

                foreach (var q in questions)
                {
                    if (!string.IsNullOrWhiteSpace(q))
                    {
                        var feed = new FeedbackQuestion
                        {
                            Qn = q
                        };
                        db.FeedbackQuestions.Add(feed);
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedbackQuestion);
        }
        catch
        {
            return View(feedbackQuestion);
        }
    }
        /// Controller For Feedback Creatation
        /// 
  
    // Controller for displaying the feedback form
    public IActionResult FeedbackForm()
    {
        var feedbackQuestions = db.FeedbackQuestions.ToList();
        var modules = db.Modules.ToList();
        var teachers = db.Teachers.ToList();

        var model = new FeedbackViewModel
        {
            FeedbackQuestions = feedbackQuestions,
            Modules = modules,
            Teachers = teachers
        };

        return View(model);
    }
        /// Controller For Index
        /// shows the No of modules, teachers, feedback questions and feedbacks
        /// 
        public IActionResult Index()
        {
            var db = new GhmDbContext();
            var modules = db.Modules.ToList();
            var teachers = db.Teachers.ToList();
            var feedbackQuestions = db.FeedbackQuestions.ToList();
            // var feedbacks = db.Feedbacks.ToList();

            var viewModel = new IndexViewModel
            {
                Modules = modules.Select(m => new ModuleViewModel
                {
                    // Map properties from Module to ModuleViewModel
                }).ToList(),
                Teachers = teachers.Select(t => new TeacherViewModel
                {
                    // Map properties from Teacher to TeacherViewModel
                }).ToList(),
                FeedbackQuestions = feedbackQuestions.Select(fq => new FeedbackQuestionViewModel
                {
                    // Map properties from FeedbackQuestion to FeedbackQuestionViewModel
                }).ToList(),
                // Feedbacks = feedbacks.Select(f => new FeedbackViewModel
                // {
                    // Map properties from Feedback to FeedbackViewModel
                // }).ToList()
            };

            return View(viewModel);
        }

        /// Controller For Module List
        /// shows the list of modules
        ///
        public IActionResult ModuleList()
        {
            var db = new GhmDbContext();
            var modules = db.Modules.Select(m => new ModuleViewModel
            {
                Id = m.Id,
                Name = m.Name
            }).ToList();

            return View(modules);
        }

        /// Controller For Teacher List
        /// shows the list of teachers
        /// 
        public IActionResult TeacherList()
        {
            var teachers = db.Teachers
            .Include(m => m.Module)
            .Select(
                t => new TeacherViewModel()
            {
                Id = t.Id,
                Name = t.Name,
                ModuleId = t.ModuleId,
                Module = t.Module.Name
                
            }).ToList();

            return View(teachers);
        }

        /// Controller For Feedback Question List
        /// shows the list of feedback questions
        ///
        public IActionResult FeedbackQuestionList()
        {

            var feedbackQuestions = db.FeedbackQuestions.Select(fq => new FeedbackQuestionViewModel
            {
                Id = fq.Id,
                Q1 = fq.Qn // For displaying purposes
            }).ToList();

            return View(feedbackQuestions);
        
        }

        /// Controller For Feedback List
        /// shows the list of feedbacks
        /// 
        // public IActionResult Feedbacks()
        // {
        //     var db = new GhmDbContext();
        //     var feedbacks = db.Feedbacks.Select(f => new FeedbackViewModel
        //     {
        //         Id = f.Id,
        //         TeacherId1 = f.TeacherId1,
        //         TeacherId2 = f.TeacherId2,
        //         TeacherId3 = f.TeacherId3,
        //         // ModuleId1 = f.ModuleId1,
        //         // ModuleId2 = f.ModuleId2,
        //         // ModuleId3 = f.ModuleId3,
        //         // FeedbackQuestionId1 = f.FeedbackQuestionId1,
        //         // FeedbackQuestionId2 = f.FeedbackQuestionId1,
        //         // FeedbackQuestionId3 = f.FeedbackQuestionId1,
        //         // FeedbackQuestionId4 = f.FeedbackQuestionId1,
        //         // Answer1 = f.Answer1,
        //         // Answer2 = f.Answer2,
        //         // Answer3 = f.Answer3,
        //         // Answer4 = f.Answer4
        //     }).ToList();

        //     return View(feedbacks);
        // }

    }
    
}