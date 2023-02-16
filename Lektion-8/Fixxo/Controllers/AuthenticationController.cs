using AutoMapper;
using Fixxo.Models.Identity;
using Fixxo.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fixxo.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthenticationController(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }






        [Route("/register")]
        public IActionResult Register(string returnUrl = null!)
        {
            var viewModel = new RegisterViewModel();
            if (returnUrl != null)
                viewModel.RegistrationForm.ReturnUrl = returnUrl;

            return View(viewModel);
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var appUser = _mapper.Map<AppUser>(viewModel.RegistrationForm);
                appUser.UserName = appUser.Email;

                var result = await _userManager.CreateAsync(appUser, viewModel.RegistrationForm.Password); 
                if (result.Succeeded)
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(appUser, viewModel.RegistrationForm.Password, false, false);
                    if (signInResult.Succeeded)
                    {
                        return LocalRedirect(viewModel.RegistrationForm.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }

                ModelState.AddModelError(string.Empty, "Unable to create an Account. Please contact customer support.");
                return View(viewModel);
            }
            else
            {
                return View(viewModel);
            }

            
        }
    }
}
