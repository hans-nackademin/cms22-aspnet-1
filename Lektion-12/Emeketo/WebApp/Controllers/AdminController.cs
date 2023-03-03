using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Contexts;
using WebApp.Models.Identity;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _context;

        public AdminController(UserManager<AppIdentityUser> userManager, RoleManager<IdentityRole> roleManager, DataContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        [Authorize(Roles = "Admin, UserAdmin")]
        public async Task<IActionResult> UserManagement()
        {

            var appIdentityUsers = await _userManager.Users.Include(x => x.Profile).ToListAsync();

            var viewModel = new AdminUserManagementViewModel();
            foreach(var user in appIdentityUsers)
            {
                var userRole = await _userManager.GetRolesAsync(user);


                viewModel.Users.Add(new AppIdentityUserWithRole
                {
                    Id = user.Id,
                    Profile = user.Profile,
                    Email = user.Email,
                    RoleName = userRole.FirstOrDefault()!
                });
            }



            return View(viewModel);
        }

        [Authorize(Roles = "Admin, UserAdmin")]
        public async Task<IActionResult> EditUser(string id)
        {
            var appIdentityUser = await _userManager.Users.Include(x => x.Profile).FirstOrDefaultAsync(x => x.Id == id);
            if (appIdentityUser != null)
            {
                var userRole = await _userManager.GetRolesAsync(appIdentityUser);

                var viewModel = new AdminEditUserViewModel
                {
                    User = new AppIdentityUserWithRole
                    {
                        Id = appIdentityUser.Id,
                        Profile = appIdentityUser.Profile,
                        Email = appIdentityUser.Email,
                        RoleName = userRole.FirstOrDefault()!
                    },
                    CurrentRoleName = userRole.FirstOrDefault()!,
                    UserId = id
                };

                return View(viewModel);
            }

            return RedirectToAction("UserManagement");
        }

        [Authorize(Roles = "Admin, UserAdmin")]
        [HttpPost]
        public async Task<IActionResult> EditUser(AdminEditUserViewModel viewModel)
        {
            var appIdentityUser = new AppIdentityUser
            {
                Id = viewModel.UserId,
                UserName = viewModel.User.UserName,
                Email = viewModel.User.Email,
                NormalizedEmail = viewModel.User.NormalizedEmail,
                NormalizedUserName = viewModel.User.NormalizedUserName
            };

            await _userManager.AddToRoleAsync(appIdentityUser, "Admin");
            await _userManager.RemoveFromRoleAsync(appIdentityUser, "User");

            return RedirectToAction("UserManagement");
        }







        [Authorize(Roles = "Admin")]
        public IActionResult SystemManagement()
        {
            return View();
        }
    }
}
