using GHM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using GHM.Models; // Add this using directive for the 'GHM.Models' namespace.


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
                    Category = issue.Category,
                    Description = issue.Description,
                    RecommendedSolution = issue.RecommendedSolution
                };
                db.Issues.Add(iss);
                db.SaveChanges();

                var resolvedIssue = new ResolvedIssues()
                {
                    IssueId = iss.Id,
                    Status = "Pending"
                };
                db.ResolvedIssues.Add(resolvedIssue);
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
            var issues = db.Issues
            // .Include(i => i.ResolvedIssues)
            .Select(i => new IssueViewModel
            {
                Id = i.Id,
                Title = i.Title,
                Category = i.Category,
                Description = i.Description,
                RecommendedSolution = i.RecommendedSolution,
                // Status = i.resolvedIssues.Status
            }).ToList();

            return View(issues);
        }

        /// Controller For Issue Delete
        /// 
        public IActionResult Delete(int id){
            var issues = db.Issues.Where(i => i.Id == id).FirstOrDefault();
            var issue = new IssueViewModel()
            {
                Id = issues.Id,
                Title = issues.Title,
                Category = issues.Category,
                Description = issues.Description,
                RecommendedSolution = issues.RecommendedSolution
            };
        
            return View(issue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            var issue = db.Issues.Where(i => i.Id == id).FirstOrDefault();
            if (issue != null)
            {
                db.Issues.Remove(issue);
            }
            db.SaveChanges();
            return RedirectToAction("IssueList");

        }

        /// COntroller For The List of Issues Status
        /// 
        public IActionResult ResolvedIssues()
        {
            var resolvedIssues = db.ResolvedIssues
            .Include(r => r.Issue)
            .Select(r => new ResolvedIssuesViewModel()
            {
                Id = r.Id,
                IssueId = r.IssueId,
                Status = r.Status,
                IssueTitle = r.Issue.Title
            }).ToList();

            return View(resolvedIssues);
        }

        /// Controller To Edit the Status of the Issue
        /// 
        public IActionResult EditStatus(int id)
        {
            var issue = db.ResolvedIssues
            .Include(r => r.Issue)
            .Select(r => new ResolvedIssuesViewModel()
            {
                Id = r.Id,
                IssueId = r.IssueId,
                Status = r.Status,
                IssueTitle = r.Issue.Title
            }).FirstOrDefault();

            return View(issue);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStatus(int id, ResolvedIssuesViewModel resolvedIssue)
        {
            try{
                var issue = db.ResolvedIssues.Where(r => r.Id == id).FirstOrDefault();
                if (resolvedIssue != null)
                {
                    issue.Status = resolvedIssue.Status;
                }
                db.SaveChanges();
                return RedirectToAction("ResolvedIssues");
            }
            catch{
                return View();
            }
        }

        /// Index Page For Issues
        /// Show the Summary of the Issues
        /// No of Issues
        /// No of Resolved Issues
        /// No of Pending Issues
        /// No of Closed Issues
        /// No of Issues in Each Category
        ///
        public IActionResult Index()
        {
            var CIssues = db.Issues.ToList().Count;
            var resolvedIssues = db.ResolvedIssues.Where(r => r.Status == "Resolved").ToList();
            var pendingIssues = db.ResolvedIssues.Where(r => r.Status == "Pending").ToList();
            var closedIssues = db.ResolvedIssues.Where(r => r.Status == "Closed").ToList();
            var issuesByCategory = db.Issues.GroupBy(i => i.Category).Select(i => new CategorySummary()
            {
                Category = i.Key,
                Count = i.Count(),
                /// Add the Count of the Issues in Each Category
                /// 
                //Tcount = db.Issues.Where(c => c.Category == i.Key).Count()

            }).ToList();

            var issuesSummary = new IssuesSummaryViewModel()
            {
                TotalIssues = CIssues,
                ResolvedIssuesCount = resolvedIssues.Count,
                PendingIssuesCount = pendingIssues.Count,
                ClosedIssuesCount = closedIssues.Count,
                IssuesByCategory = issuesByCategory
            };

            return View(issuesSummary);
        }

    }
}