using BetterWorld.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BetterWorld.Controllers
{
    
    public class JobController : Controller
    {
        BetterWorldDbContext db_context = new BetterWorldDbContext();
        BetterWorldDbContext _dbContext = new BetterWorldDbContext();
        [Authorize(Policy = "View")]
        public ActionResult Index(int CurrentPage = 1, int PageSize = 10)
        {
            var job_list = db_context.Jobs
                .Include(j => j.User)
                .Include(j => j.Organization)
                .Select(x => new JobViewModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    Title = x.Title,
                    OrganizationId = x.OrganizationId,
                    OrganizationName = x.Organization.Name,
                    CreatedBy = x.User.UserName
                });
            if (job_list != null)
            {
                var paged_list = job_list.OrderBy(x => x.Id)
                    .Skip((CurrentPage - 1) * PageSize)
                    .Take(PageSize).ToList();
                var new_list = new PaginatedJobViewModel()
                {
                    Count = job_list.Count(),
                    CurrentPage = CurrentPage,
                    PageSize = PageSize,
                    Data = paged_list

                };
                return View(new_list);

            }
            else
            {
                return View(Enumerable.Empty<PaginatedJobViewModel>());
            }
        }

        // GET: JobController/Details/5
        [Authorize(Policy = "View")]
        public ActionResult Details(int id)
        {
            var job_detail = db_context.Jobs.Include(x => 
            x.Organization).Where(x => x.Id == id).FirstOrDefault();
            var mapped_job = new JobViewModel()
            {
                Id = job_detail.Id, 
                Title = job_detail.Title,
                Description = job_detail.Description,
                OrganizationName = job_detail.Organization.Name,
            };
            return View(mapped_job);
        }

        // GET: JobController/Create
        [Authorize(Policy = "Recruiter")]
        public ActionResult Create()
        {
            var org_list = db_context.Organizations.Select( x => new OrganizationViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            ViewBag.Organizations = org_list;
            return View();
        }

        // POST: JobController/Create
        [Authorize(Policy = "Recruiter")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobViewModel jvm)
        {
            
            try
            {
                var entity = new Job() 
                {
                    Title = jvm.Title,
                    Description = jvm.Description,
                    UserId = Convert.ToInt32(HttpContext.User.Claims.ElementAt(1).Value),
                    OrganizationId = jvm.OrganizationId,
                };
                db_context.Jobs.Add(entity);
                db_context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobController/Edit/5
        [Authorize(Policy = "Recruiter")]

        public ActionResult Edit(int id)
        {
            var jobViewModel = db_context.Jobs
                .Include(x => x.Organization)
                .Select(x => new JobViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    OrganizationId = x.OrganizationId,
                    OrganizationName = x.Organization.Name
                })
                .FirstOrDefault(x => x.Id == id);

            if (jobViewModel == null)
            {
                return NotFound();
            }

            ViewBag.Organizations = new SelectList(db_context.Organizations, "Id", "Name", jobViewModel.OrganizationId);

            return View(jobViewModel);
        }

        // POST: JobsController/Edit/5
        [Authorize(Policy = "Recruiter")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobViewModel jobViewModel)
        {
            var job = db_context.Jobs.Find(jobViewModel.Id);
            if (job == null)
            {
                return NotFound();
            }

            job.Title = jobViewModel.Title;
            job.Description = jobViewModel.Description;
            job.OrganizationId = jobViewModel.OrganizationId;

            db_context.Entry(job).State = EntityState.Modified;
            db_context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: JobController/Delete/5
        [Authorize(Policy = "Recruiter")]
        public ActionResult Delete(int id)
        {
            var job_detail = db_context.Jobs.Include(x =>
            x.Organization).Where(x => x.Id == id).FirstOrDefault();
            var delete_job = new JobViewModel()
            {
                Id = job_detail.Id,
                Title = job_detail.Title,
                Description = job_detail.Description,
                OrganizationName = job_detail.Organization.Name,
            };
            return View(delete_job);
        }

        // POST: JobController/Delete/5
        [Authorize(Policy = "Recruiter")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,IFormCollection collection)
        {
            try
            {
                var entity = db_context.Jobs.Where(x => x.Id == id).FirstOrDefault();
                db_context.Jobs.Remove(entity);
                db_context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
