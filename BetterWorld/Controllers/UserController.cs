using BetterWorld.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;

namespace BetterWorld.Controllers
{
    public class UserController : Controller
    {
        BetterWorldDbContext db_context = new BetterWorldDbContext();
        BetterWorldDbContext _context = new BetterWorldDbContext();
        public ActionResult Register()
        {
            return View();
        }
        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserViewModel uvm)
        {
            try
            {
                var user_exists = db_context.Users.Any(x => x.UserName == uvm.UserName);
                if (!user_exists)
                {
                    var entity = new User()
                    {
                        UserName = uvm.UserName,
                    };
                    var hasher = new PasswordHasher<User>();
                    entity.Password = hasher.HashPassword(entity, uvm.Password);
                    entity.AccountType = uvm.AccountType;
                    db_context.Users.Add(entity);
                    db_context.SaveChanges();

                    return RedirectToAction(nameof(Login));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Details/5
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViewModel vm)
        {
            var db_user = db_context.Users.Where(x =>
                x.UserName == vm.UserName).FirstOrDefault();
            if (db_user != null)
            {
                var hasher = new PasswordHasher<User>();
                var result = hasher.VerifyHashedPassword(db_user, db_user.Password, vm.Password);
                if (result == PasswordVerificationResult.Success)
                {
                    var claims = new List<Claim>
            {
            //new Claim("Id", db_user.Id),
                new Claim(ClaimTypes.Name, db_user.UserName),
                new Claim(ClaimTypes.NameIdentifier, db_user.Id.ToString()),
                new Claim("AccountType", db_user.AccountType.ToString())
            };

                    var claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                    };
                    authProperties.Items.Add("AccountType", db_user.AccountType.ToString());

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );
                    return RedirectToAction("Index", "Job");
                }
            }
            return View();
        }
        // GET: UserController/Create
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home"); // Replace with the desired action and controller
        }

        //dotnet add package Microsoft.AspNetCore.Authentication.Cookies

        public async Task<IActionResult> Index()
        {
            var applicationList = await _context.Users
                //.Include(x => x.Organization)
                //.Include(j => j.User)
                .Select(x => new UserViewModel
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    AccountType = x.AccountType,
                    
                    //Email = x.Email,
                    //OrganizationId = x.OrganizationId,
                    //Organization = x.Organization.Name,
                })
                .ToListAsync();

            return View(applicationList);
        }

        public ActionResult Details(int id)
        {
            var profile_detail = db_context.re
            .Include(x =>x.Organization).Include(x => x.User).Where(x => id == x.User.Id).FirstOrDefault();
            if (profile_detail == null)
            {
                var userName = User.Identity?.Name;
                var userew = db_context.Users.Where(x => id == x.Id).FirstOrDefault();
                var mapped_user = new review()
                {
                    Id = userew.Id,
                    UserName = userew.UserName,
                    AccountType = userew.AccountType
                };
                
                if ( userName == mapped_user.UserName)
                {
                    return RedirectToAction("Create");
                }
                else
                {
                    return View(mapped_user);
                }
            }
            else
            {
                var mapped_profile = new review()
                {
                    Id = profile_detail.Id,
                    UserName = profile_detail.User.UserName,
                    AccountType = profile_detail.User.AccountType,
                    Bio = profile_detail.Bio,
                    Age = profile_detail.Age,
                    Skills = profile_detail.Skills,
                    Organization = profile_detail.Organization.Name,
                    Location = profile_detail.Location,
                    Email = profile_detail.Email,
                    PhoneNo = profile_detail.PhoneNo

                };

                return View(mapped_profile);
            }
        }

        public ActionResult Create (int id)
        {
            var org = db_context.Organizations.Select(x => new OrganizationViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            ViewBag.Organizations = org;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(review jvm)
        {

            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    var entity = new re()
                    {
                        //OrganizationId = 0,
                        //Skills = null,
                        Bio = jvm.Bio,
                        Age = jvm.Age,
                        Skills = jvm.Skills,
                        Location = jvm.Location,
                        //Pic = memoryStream.ToArray(),
                        //PicFileName = jvm.PicFile.FileName,
                        //PicContentType = jvm.PicFile.ContentType,
                        Email = jvm.Email,
                        PhoneNo = jvm.PhoneNo,
                        UserId = Convert.ToInt32(HttpContext.User.Claims.ElementAt(1).Value),
                        OrganizationId = jvm.OrganizationId
                    };
                    db_context.Add(entity);
                    db_context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {

            var org = db_context.re.Include(x => x.User).Include(x => x.Organization).Where(x => id == x.UserId).Select(x=> new review()
            {
                Id = x.Id,
                UserName = x.User.UserName,
                OrganizationId = x.OrganizationId,
                Organization = x.Organization.Name,
                Bio = x.Bio,
                Age = x.Age,
                Skills = x.Skills,
                Location = x.Location,
                Email = x.Email,
                PhoneNo = x.PhoneNo,
            }).FirstOrDefault();

            if (org == null)
            {
                return NotFound();
            }
            ViewBag.Organizations = new SelectList(db_context.Organizations, "Id", "Name", org.OrganizationId);
            return View(org);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(review rizz)
        {
            var ri = db_context.re.Find(rizz.Id);
            if (ri == null)
            {
                return NotFound();
            }

            using (var memoryStream = new MemoryStream())
            {
                ri.OrganizationId = rizz.OrganizationId;
                ri.UserId = Convert.ToInt32(HttpContext.User.Claims.ElementAt(1).Value);
                ri.Bio = rizz.Bio;
                ri.Age = rizz.Age;
                ri.Skills = rizz.Skills;
                ri.Location = rizz.Location;
                ri.Email = rizz.Email;
                ri.PhoneNo = rizz.PhoneNo;
                //ri.Pic = memoryStream.ToArray();
                //ri.PicFileName = rizz.PicFile.FileName;
                //ri.PicContentType = rizz.PicFile.ContentType;
                db_context.Entry(ri).State = EntityState.Modified;
                db_context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        }
}