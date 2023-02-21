using _01_Identity_Roles_Claims.Contexts;
using _01_Identity_Roles_Claims.Models.Entitites;
using _01_Identity_Roles_Claims.Models.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _01_Identity_Roles_Claims.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IdentityContext _identityContext;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IdentityContext identityContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityContext = identityContext;
        }

        [AllowAnonymous]
        public async Task<IActionResult> SignUp(string ReturnUrl = null!)
        {
            if (!await _userManager.Users.AnyAsync())
                return RedirectToAction("Installation", "Admin");

            var form = new SignUpForm
            {
                ReturnUrl = ReturnUrl ?? Url.Content("~/")
            };

            return View(form);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpForm form)
        {
            if (ModelState.IsValid)
            {
                if (await _userManager.Users.AnyAsync(x => x.Email == form.Email))
                {
                    ModelState.AddModelError(string.Empty, "A user with the same email already exists.");
                    return View(form);
                }

                var identityUser = new IdentityUser
                {
                    Email = form.Email,
                    UserName = form.Email
                };

                var result = await _userManager.CreateAsync(identityUser, form.Password);
                if (result.Succeeded)
                {
                    _identityContext.UserProfile.Add(new UserProfileEntity
                    {
                        UserId = identityUser.Id,
                        FirstName = form.FirstName,
                        LastName = form.LastName,
                        StreetName = form.StreetName ?? null!,
                        PostalCode = form.PostalCode ?? null!,
                        City = form.City ?? null!
                    });
                    await _identityContext.SaveChangesAsync();

                    await _userManager.AddToRoleAsync(identityUser, "User");

                    var signInResult = await _signInManager.PasswordSignInAsync(identityUser, form.Password, false, false);
                    if (signInResult.Succeeded)
                        return LocalRedirect(form.ReturnUrl);
                    else
                        return RedirectToAction("SignIn");
                }
            }

            ModelState.AddModelError(string.Empty, "Unable to create an Account.");
            return View(form);
        }


        [AllowAnonymous]
        public IActionResult SignIn(string ReturnUrl = null!)
        {
            var form = new SignInForm
            {
                ReturnUrl = ReturnUrl ?? Url.Content("~/")
            };

            return View(form);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInForm form)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false);
                if (result.Succeeded)
                    return LocalRedirect(form.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "Incorrect email or password");
            return View(form);
        }

        public async Task<IActionResult> SignOut()
        {
            if (_signInManager.IsSignedIn(User))
                await _signInManager.SignOutAsync();

            return LocalRedirect("/");
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Tickets()
        {
            return View();
        }
    }
}
