using BetterWorld.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetterWorld.Controllers
{
    public class OrganizationController : Controller
    {
        BetterWorldDbContext db_context = new BetterWorldDbContext();
        // GET: OrganizationController
        [Authorize(Policy = "View")]
        public ActionResult Index()
        {
            var org_list = db_context.Organizations.ToList();
            if (org_list != null)
            {
                var mapped_list = org_list.Select(x => new OrganizationViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    ContactNo = x.ContactNo.ToString(),
                }).ToList();
                return View(mapped_list);
            }
            else
            {
                IEnumerable<OrganizationViewModel> list = Enumerable.Empty<OrganizationViewModel>();
                return View(list);
            }
        }

        // GET: OrganizationController/Details/5
        [Authorize(Policy = "View")]
        public ActionResult Details(int id)
        {
            var org_detail = db_context.Organizations.Where(x => x.Id == id)
                .FirstOrDefault();
            var mapped_detail = new OrganizationViewModel();
            mapped_detail.Id = org_detail.Id;
            mapped_detail.Name = org_detail.Name;
            mapped_detail.Address = org_detail.Address;
            mapped_detail.ContactNo = org_detail.ContactNo.ToString();
            return View(mapped_detail);
        }

        // GET: OrganizationController/Create
        [Authorize(Policy = "Recruiter")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganizationController/Create
        [Authorize(Policy = "Recruiter")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrganizationViewModel ovm)
        {
            try
            {
                var entity = new Organization();
                entity.Name = ovm.Name;
                entity.Address = ovm.Address;
                entity.ContactNo = Convert.ToInt32(ovm.ContactNo);

                db_context.Organizations.Add(entity);
                db_context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Edit/5
        [Authorize(Policy = "Recruiter")]
        public ActionResult Edit(int id)
        {
            var edit_detail = db_context.Organizations.Where(x => x.Id == id).FirstOrDefault();

            var mapped_detail = new OrganizationViewModel();

            mapped_detail.Id = edit_detail.Id;
            mapped_detail.Name = edit_detail.Name;
            mapped_detail.Address = edit_detail.Address;
            mapped_detail.ContactNo = edit_detail.ContactNo.ToString();

            return View(mapped_detail);
        }

        // POST: OrganizationController/Edit/5
        [Authorize(Policy = "Recruiter")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrganizationViewModel ovm)
        {
            try
            {
                var entity = new Organization();

                entity.Id = id;
                entity.Name = ovm.Name;
                entity.ContactNo = Convert.ToInt32(ovm.ContactNo);
                entity.Address = ovm.Address;

                db_context.Organizations.Update(entity); 
                db_context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Delete/5
        [Authorize(Policy = "Recruiter")]
        public ActionResult Delete(int id)
        {
            var org_detail = db_context.Organizations.Where(x => x.Id == id)
                .FirstOrDefault();
            var mapped_detail = new OrganizationViewModel();
            mapped_detail.Id = org_detail.Id;
            mapped_detail.Name = org_detail.Name;
            mapped_detail.Address = org_detail.Address;
            mapped_detail.ContactNo = org_detail.ContactNo.ToString();
            return View(mapped_detail);
        }

        // POST: OrganizationController/Delete/5
        [Authorize(Policy = "Recruiter")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrganizationViewModel ovm)
        {
            try
            {
                var entity = db_context.Organizations.Where(x => x.Id == id).FirstOrDefault();  

                db_context.Organizations.Remove(entity);
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
