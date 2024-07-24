using BetterWorld.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BetterWorld.Controllers
{
    public class ApplicationController : Controller
    {
        BetterWorldDbContext _dbContext = new BetterWorldDbContext();


        // GET: ApplicationController
        [Authorize(Policy = "View")]
        public async Task<IActionResult> Index()
        {
            var applicationList = await _dbContext.Application
                .Include(x => x.Job)
                .Include(j => j.User)
                .Select(x => new ApplicationViewModel
                {
                    Id = x.Id,
                    Name = x.User.UserName,
                    Email = x.Email,
                    JobId = x.JobId,
                    JobName = x.Job.Title
                })
                .ToListAsync();

            return View(applicationList);
        }

        // GET: ApplicationController/Create

        [Authorize(Policy = "Seeker")]
        public async Task<IActionResult> Apply(int id)
        {
            var job = await _dbContext.Jobs
                .Select(x => new JobViewModel
                {
                    Id = x.Id,
                    Title = x.Title
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            var jobs = await _dbContext.Jobs
                .Select(x => new JobViewModel
                {
                    Id = x.Id,
                    Title = x.Title
                })
                .ToListAsync();

            ViewBag.Jobs = new SelectList(jobs, "Id", "Title");

            return View();
        }


        // POST: ApplicationController/Create
        [Authorize(Policy = "Seeker")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply(ApplicationViewModel avm)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await avm.CVFile.CopyToAsync(memoryStream);
                    var entity = new Application
                    {
                        UserId = Convert.ToInt32(HttpContext.User.Claims.ElementAt(1).Value),
                        Email = avm.Email,
                        CV = memoryStream.ToArray(),
                        CVFileName = avm.CVFile.FileName,
                        CVContentType = avm.CVFile.ContentType,
                        JobId = avm.JobId
                    };

                    _dbContext.Application.Add(entity);
                    await _dbContext.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            catch
            {
                var jobs = await _dbContext.Jobs
                .Select(x => new JobViewModel
                {
                    Id = x.Id,
                    Title = x.Title
                })
                .ToListAsync();

                ViewBag.Jobs = jobs;
                return View(avm);
            }
        }

        // GET: ApplicationController/Details/5
        [Authorize(Policy = "View")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationDetails = await _dbContext.Application
                .Include(x => x.Job)
                .Include(j => j.User)
                .Select(x => new ApplicationViewModel
                {
                    Id = x.Id,
                    Name = x.User.UserName,
                    Email = x.Email,
                    JobId = x.JobId,
                    JobName = x.Job.Title,
                    CVFileName = x.CVFileName,
                    CVContentType = x.CVContentType
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (applicationDetails == null)
            {
                return NotFound();
            }

            return View(applicationDetails);
        }

        // GET: ApplicationController/DownloadCV/5
        public async Task<IActionResult> DownloadCV(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _dbContext.Application.FirstOrDefaultAsync(x => x.Id == id);

            if (application == null || application.CV == null)
            {
                return NotFound();
            }

            return File(application.CV, application.CVContentType, application.CVFileName);
        }

    }
}