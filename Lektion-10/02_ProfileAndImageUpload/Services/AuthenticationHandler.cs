using _02_ProfileAndImageUpload.Models.Contexts;
using _02_ProfileAndImageUpload.Models.Entitites;
using _02_ProfileAndImageUpload.Models.Forms;
using _02_ProfileAndImageUpload.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _02_ProfileAndImageUpload.Services
{
    public class AuthenticationHandler
    {
        #region constructors

        private readonly DataContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ProfileHandler _profileHandler;

        public AuthenticationHandler(DataContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ProfileHandler profileHandler)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _profileHandler = profileHandler;
        }

        #endregion

        #region SignUp

        public async Task<IActionResult> SignUpAsync(SignUpForm form)
        {
            if (await _context.Users.AnyAsync(x => x.Email == form.Email))
                return new ConflictResult();

            var identityUser = new IdentityUser
            {
                UserName = form.Email,
                Email = form.Email
            };

            var result = await _userManager.CreateAsync(identityUser, form.Password);
            if (result.Succeeded)
            {
                var profileEntity = new ProfileEntity()
                {
                    UserId = identityUser.Id,
                    FirstName = form.FirstName,
                    LastName = form.LastName
                };

                if(form.ProfileImage != null) 
                    profileEntity.ImageName = await _profileHandler.UploadProfileImageAsync(form.ProfileImage);

                _context.Add(profileEntity);
                await _context.SaveChangesAsync();

                return new OkResult();
            }
                

            return new BadRequestResult();
        }

        #endregion

        #region SignIn

        public async Task<IActionResult> SignInAsync(SignInForm form)
        {
            if (await _context.Users.AnyAsync(x => x.Email == form.Email))
            {
                var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false);
                if (result.Succeeded)
                    return new OkResult();
            }

            return new BadRequestResult();
        }

        #endregion

        #region SignOut


        public async Task SigOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        #endregion
    }
}
