using Microsoft.AspNetCore.Mvc;
using BetterWorld.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BetterWorld.Controllers
{
    public class UserProfileController : Controller
    {
        BetterWorldDbContext _context = new BetterWorldDbContext();


        public async Task<IActionResult> Index()
        {
            var applicationList = await _context.re
                //.Include(x => x.Organization)
                //.Include(j => j.User)
                .Select(x => new UserProfileModel
                {
                    //Id = x.UserId,
                    //UserName = x.User.UserName,
                    //Email = x.Email,
                    //OrganizationId = x.OrganizationId,
                    //Organization = x.Organization.Name,
                })
                .ToListAsync();

            return View(applicationList);
        }


        //public async Task<IActionResult> Index()
        //{
        //    // Get the username from the cookie
        //    var userName = User.Identity?.Name;

        //    // Fetch the user data from the database
        //    var user = await _context.Users
        //        .FirstOrDefaultAsync(u => u.UserName == userName);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    var viewModel = await _context.UserProfile
        //.Include(j => j.User)
        //.Include(j => j.Organization)
        //.Select(j => new UserProfileModel()).FirstOrDefaultAsync();
        //    // Create a view model object
        //    var viewMode = new UserProfileModel
        //    {
        //        UserId = user.Id,
        //        UserName = user.UserName,
        //        AccountType = user.AccountType,
        //        Age = viewModel.Age,
        //        Skills = viewModel.Skills,

        //        Location = viewModel.Location,
        //        Email = viewModel.Email,
        //        PhoneNo = viewModel.PhoneNo,
        //        Bio = viewModel.Bio
        //    };

        //    return View(viewMode);
        //}
    }
}