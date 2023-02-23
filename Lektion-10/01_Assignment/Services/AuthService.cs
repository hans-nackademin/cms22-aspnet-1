using _01_Assignment.Contexts;
using _01_Assignment.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _01_Assignment.Services
{
    public class AuthService
    {
        private readonly DataContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthService(DataContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> CreateUserAsync(SignUpForm form)
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
                return new OkResult();

            return new BadRequestResult();
        }

        public async Task<IActionResult> LoginUserAsync(SignInForm form)
        {
            if (await _context.Users.AnyAsync(x => x.Email == form.Email))
            {
                var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false);
                if (result.Succeeded)
                    return new OkResult();
            }

            return new BadRequestResult();
        }


        public async Task SigOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}