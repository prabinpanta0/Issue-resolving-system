using GHM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GHM.Controllers
{
    public class All : Controller
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
                return RedirectToAction("Index");
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

        /// Controller For Feedback Question Creatation
        /// 
        public IActionResult CreateFeedbackQuestion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFeedbackQuestion(FeedbackQuestionViewModel feedbackQuestion)
        {
            try{
                var feed = new FeedbackQuestion()
                {
                    Q1 = feedbackQuestion.Q1,
                    Q2 = feedbackQuestion.Q2,
                    Q3 = feedbackQuestion.Q3,
                    Q4 = feedbackQuestion.Q4
                };

                db.FeedbackQuestions.Add(feed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch{
                return View();
            }
        }

        /// Controller For Feedback Creatation
        /// 
        public IActionResult Feedback()
        {
            ///show Teacher, Module and FeedbackQuestion list
            /// To show the user the list of teachers, modules and feedback questions and Insert the feedback
            var db = new GhmDbContext();

            var teachers = db.Teachers.Select(t => new TeacherViewModel
            {
                Id = t.Id,
                Name = t.Name
            }).ToList();

            var modules = db.Modules.Select(m => new ModuleViewModel
            {
                Id = m.Id,
                Name = m.Name
            }).ToList();

            var feedbackQuestions = db.FeedbackQuestions.Select(fq => new FeedbackQuestionViewModel
            {
                Id = fq.Id,
                Q1 = fq.Q1,
                Q2 = fq.Q2,
                Q3 = fq.Q3,
                Q4 = fq.Q4
            }).ToList();
        
            ViewBag.Teachers = teachers;
            ViewBag.Modules = modules;
            ViewBag.FeedbackQuestions = feedbackQuestions;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Feedback(FeedbackViewModel feedback)
        {
            try{
                var feed = new Feedback()
                {
                    TeacherId1 = feedback.TeacherId1,
                    TeacherId2 = feedback.TeacherId2,
                    TeacherId3 = feedback.TeacherId3,
                    ModuleId2 = feedback.ModuleId1,
                    ModuleId1 = feedback.ModuleId2,
                    ModuleId3 = feedback.ModuleId3,
                    FeedbackQuestionId1 = feedback.FeedbackQuestionId1,
                    FeedbackQuestionId2 = feedback.FeedbackQuestionId2,
                    FeedbackQuestionId3 = feedback.FeedbackQuestionId3,
                    FeedbackQuestionId4 = feedback.FeedbackQuestionId4,
                    Answer1 = feedback.Answer1,
                    Answer2 = feedback.Answer2,
                    Answer3 = feedback.Answer3,
                    Answer4 = feedback.Answer4
                };

                db.Feedbacks.Add(feed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch{
                return View();
            }
        }


        /// Controller For Index
        /// shows the No of modules, teachers, feedback questions and feedbacks
        /// 
        public IActionResult Index()
        {
            var db = new GhmDbContext();
            var modules = db.Modules.Count();
            var teachers = db.Teachers.Count();
            var feedbackQuestions = db.FeedbackQuestions.Count();
            var feedbacks = db.Feedbacks.Count();

            ViewBag.Modules = modules;
            ViewBag.Teachers = teachers;
            ViewBag.FeedbackQuestions = feedbackQuestions;
            ViewBag.Feedbacks = feedbacks;

            return View();
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
            var db = new GhmDbContext();
            var teachers = db.Teachers.Select(t => new TeacherViewModel
            {
                Id = t.Id,
                Name = t.Name
            }).ToList();

            return View(teachers);
        }

        /// Controller For Feedback Question List
        /// shows the list of feedback questions
        ///
        public IActionResult FeedbackQuestionList()
        {
            var db = new GhmDbContext();
            var feedbackQuestions = db.FeedbackQuestions.Select(fq => new FeedbackQuestionViewModel
            {
                Id = fq.Id,
                Q1 = fq.Q1,
                Q2 = fq.Q2,
                Q3 = fq.Q3,
                Q4 = fq.Q4
            }).ToList();

            return View(feedbackQuestions);
        }

        /// Controller For Feedback List
        /// shows the list of feedbacks
        /// 
        public IActionResult FeedbackList()
        {
            var db = new GhmDbContext();
            var feedbacks = db.Feedbacks.Select(f => new FeedbackViewModel
            {
                Id = f.Id,
                TeacherId1 = f.TeacherId1,
                TeacherId2 = f.TeacherId2,
                TeacherId3 = f.TeacherId3,
                ModuleId1 = f.ModuleId1,
                ModuleId2 = f.ModuleId2,
                ModuleId3 = f.ModuleId3,
                FeedbackQuestionId1 = f.FeedbackQuestionId1,
                FeedbackQuestionId2 = f.FeedbackQuestionId2,
                FeedbackQuestionId3 = f.FeedbackQuestionId3,
                FeedbackQuestionId4 = f.FeedbackQuestionId4,
                Answer1 = f.Answer1,
                Answer2 = f.Answer2,
                Answer3 = f.Answer3,
                Answer4 = f.Answer4
            }).ToList();

            return View(feedbacks);
        }

    }
    
}