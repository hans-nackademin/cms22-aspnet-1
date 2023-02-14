using _03_Fixxo.Models;
using _03_Fixxo.Models.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _03_Fixxo.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        #region Login


        [Route("/login")]
        public IActionResult Login(string returnUrl = null!)
        {
            var form = new LoginFormModel();
            if(returnUrl != null)
                form.ReturnUrl = returnUrl;

            return View(form);
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login(LoginFormModel form)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, form.RememberMe, false);

                if (result.Succeeded)
                    return LocalRedirect(form.ReturnUrl);

                ModelState.AddModelError(string.Empty, "Incorrect email or password");
            
            }

            return View(form);
        }

        #endregion

        #region Register

        [Route("/register")]
        public IActionResult Register(string returnUrl = null!)
        {
            var form = new RegisterFormModel();
            if (returnUrl != null)
                form.ReturnUrl = returnUrl;

            return View(form);
        }


        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register(RegisterFormModel form)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser() 
                { 
                    UserName = form.Email,
                    Email = form.Email,
                    FirstName= form.FirstName,
                    LastName= form.LastName
                };

                var result = await _userManager.CreateAsync(user, form.Password);
                if (result.Succeeded)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false);
                    if (signInResult.Succeeded)
                        return LocalRedirect(form.ReturnUrl);
                    else
                        return RedirectToAction("Login", "Authentication");
                }

                ModelState.AddModelError(string.Empty, "Unable to create an account. Please contact customer support.");
            }

            return View(form);
        }




        #endregion
    }
}
