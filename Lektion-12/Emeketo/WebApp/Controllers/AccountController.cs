using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Contexts;
using WebApp.Models.Entitites;
using WebApp.Models.Forms;
using WebApp.Models.Identity;
using WebApp.Models.Profile;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _context;

        public AccountController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, DataContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new AccountIndexViewModel();
            var appIdentityUser = await _userManager.Users.Include(x => x.Profile).FirstOrDefaultAsync(x => x.UserName == User.Identity!.Name);

            if (appIdentityUser != null)
            {
                viewModel.Profile = new UserProfile
                {
                    UserId = appIdentityUser.Id,
                    FirstName = appIdentityUser.Profile.FirstName,
                    LastName = appIdentityUser.Profile.LastName,
                    Email = appIdentityUser.Email!,
                    StreetName = appIdentityUser.Profile.StreetName,
                    PostalCode = appIdentityUser.Profile.PostalCode,
                    City = appIdentityUser.Profile.City
                };
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit()
        {
            var viewModel = new AccountEditViewModel();
            var appIdentityUser = await _userManager.Users.Include(x => x.Profile).FirstOrDefaultAsync(x => x.UserName == User.Identity!.Name);

            if (appIdentityUser != null)
            {
                viewModel.UserId = appIdentityUser.Id;
                viewModel.Form = new ProfileEditForm
                {
                    FirstName = appIdentityUser.Profile.FirstName,
                    LastName = appIdentityUser.Profile.LastName,
                    StreetName = appIdentityUser.Profile.StreetName,
                    PostalCode = appIdentityUser.Profile.PostalCode,
                    City = appIdentityUser.Profile.City
                };
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AccountEditViewModel viewModel)
        {
            var appIdentityUser = await _userManager.Users.Include(x => x.Profile).FirstOrDefaultAsync(x => x.UserName == User.Identity!.Name);
            var userProfileEntity = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == appIdentityUser!.ProfileId);

            if (userProfileEntity != null)
            {
                userProfileEntity.FirstName = viewModel.Form.FirstName;
                userProfileEntity.LastName = viewModel.Form.LastName;
                userProfileEntity.StreetName = viewModel.Form.StreetName;
                userProfileEntity.PostalCode = viewModel.Form.PostalCode;
                userProfileEntity.City = viewModel.Form.City;

                _context.Update(userProfileEntity);
                await _context.SaveChangesAsync();
            } 

            return RedirectToAction("Index");
        
        }







        [AllowAnonymous]
        public IActionResult Register(string ReturnUrl = null!)
        {
            var viewModel = new RegisterViewModel();
            viewModel.ReturnUrl = ReturnUrl ?? Url.Content("/");

            return View(viewModel);
        }

        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl = null!)
        {
            var viewModel = new LoginViewModel();
            viewModel.ReturnUrl = ReturnUrl ?? Url.Content("/");

            return View(viewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {

            
            if (ModelState.IsValid)
            {
                var userRole = "User";
                
                if (!await _roleManager.Roles.AnyAsync() && !await _userManager.Users.AnyAsync())
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                    await _roleManager.CreateAsync(new IdentityRole("User"));

                    userRole = "Admin";
                }

                if (await _userManager.Users.AnyAsync(x => x.Email == viewModel.Form.Email))
                {
                    ModelState.AddModelError(string.Empty, "A user with the same email adress already exists.");
                    return View(viewModel);
                }

                var userProfileEntity = new UserProfileEntity
                {
                    FirstName = viewModel.Form.FirstName,
                    LastName = viewModel.Form.LastName,
                    StreetName = viewModel.Form.StreetName,
                    PostalCode = viewModel.Form.PostalCode,
                    City = viewModel.Form.City
                };

                _context.Add(userProfileEntity);
                await _context.SaveChangesAsync();

                var appIdentityUser = new AppIdentityUser
                {
                    Email = viewModel.Form.Email,
                    UserName = viewModel.Form.Email,
                    ProfileId = userProfileEntity.Id
                };

                var result = await _userManager.CreateAsync(appIdentityUser, viewModel.Form.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appIdentityUser, userRole);

                    var signInResult = await _signInManager.PasswordSignInAsync(appIdentityUser, viewModel.Form.Password, false, false);
                    if (signInResult.Succeeded)
                        return LocalRedirect(viewModel.ReturnUrl);
                    else
                        return RedirectToAction("Login");
                }

            }

            ModelState.AddModelError(string.Empty, "Unable to create an Account.");
            return View(viewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(viewModel.Form.Email, viewModel.Form.Password, false, false);
                if (signInResult.Succeeded)
                    return LocalRedirect(viewModel.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "Incorrect email or password");
            return View(viewModel);
        }

    }
}
