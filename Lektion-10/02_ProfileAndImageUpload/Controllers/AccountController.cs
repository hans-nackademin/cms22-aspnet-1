using _02_ProfileAndImageUpload.Models.Forms;
using _02_ProfileAndImageUpload.Models.Identity;
using _02_ProfileAndImageUpload.Models.ViewModels.Account;
using _02_ProfileAndImageUpload.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _02_ProfileAndImageUpload.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthenticationHandler _auth;
        private readonly ProfileHandler _profileHandler;

        public AccountController(AuthenticationHandler auth, ProfileHandler profileHandler)
        {
            _auth = auth;
            _profileHandler = profileHandler;
        }

        public IActionResult SignUp(string ReturnUrl)
        {
            var form = new SignUpForm { ReturnUrl = ReturnUrl ?? Url.Content("/") };
            return View(form);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpForm form)
        {
            if (ModelState.IsValid)
            {
                var result = await _auth.SignUpAsync(form);
                if (result is OkResult)
                    return LocalRedirect(form.ReturnUrl);
                else if (result is ConflictResult)
                    ModelState.AddModelError("", "User with the same email already exists");
                else
                    ModelState.AddModelError("", "An unexpected error occured!");
            }

            return View(form);
        }


        public IActionResult SignIn(string ReturnUrl)
        {
            var form = new SignInForm { ReturnUrl = ReturnUrl ?? Url.Content("/") };
            return View(form);
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInForm form)
        {
            if (ModelState.IsValid)
            {
                var result = await _auth.SignInAsync(form);
                if (result is OkResult)
                    return LocalRedirect(form.ReturnUrl);
                else
                    ModelState.AddModelError("", "Incorrect email or password");
            }

            return View(form);
        }


        public async Task<IActionResult> SignOut()
        {
            await _auth.SigOutAsync();
            return RedirectToAction("Index", "Home");
        }




        [Authorize]
        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.Profile = await _profileHandler.GetProfileAsync(User.Identity!.Name!);

            return View(viewModel);
        }
    }
}
