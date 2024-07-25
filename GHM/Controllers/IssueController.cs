using GHM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using Microsoft.AspNetCore.Mvc;


namespace GHM.Controller
{
    public class IssueController : Microsoft.AspNetCore.Mvc.Controller
    {
        GhmDbContext db = new GhmDbContext();

        /// Controller For Issue Creatation
        /// 
        public IActionResult CreateIssue()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateIssue(IssueViewModel issue)
        {
            try{
                var iss = new Issue()
                {
                    Title = issue.Title,
                    Description = issue.Description,
                    RecommendedSolution = issue.RecommendedSolution
                };
                db.Issues.Add(iss);
                db.SaveChanges();
                return RedirectToAction("IssueList");
            }
            catch{
                return View();
            }
        }

        /// Controller For Issue List
        /// 
        public IActionResult IssueList()
        {
            var issues = db.Issues.Select(i => new IssueViewModel
            {
                Id = i.Id,
                Title = i.Title,
                Description = i.Description,
                RecommendedSolution = i.RecommendedSolution
            }).ToList();

            return View(issues);
        }
    }
}