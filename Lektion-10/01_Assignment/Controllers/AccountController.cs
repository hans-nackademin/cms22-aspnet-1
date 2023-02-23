using _01_Assignment.Models;
using _01_Assignment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _01_Assignment.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult SignUp(string ReturnUrl = null!)
        {
            var form = new SignUpForm();
            form.ReturnUrl = ReturnUrl ?? Url.Content("/");

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpForm form)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.CreateUserAsync(form);
                if (result is OkResult)
                    return LocalRedirect(form.ReturnUrl);
                else if (result is ConflictResult)
                    ModelState.AddModelError("", "User with the same email already exists");
                else
                    ModelState.AddModelError("", "An unexpected error occured!");
            }

            return View(form);
        }


        public IActionResult SignIn(string ReturnUrl = null!)
        {
            var form = new SignInForm();
            form.ReturnUrl = ReturnUrl ?? Url.Content("/");

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInForm form)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginUserAsync(form);
                if (result is OkResult)
                    return LocalRedirect(form.ReturnUrl);
                else
                    ModelState.AddModelError("", "Incorrect email or password");
            }

            return View(form);
        }


        public async Task<IActionResult> SignOut()
        {
            await _authService.SigOutAsync();
            return RedirectToAction("Index", "Home");
        }



        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
