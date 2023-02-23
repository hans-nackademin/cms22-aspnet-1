using _02_ProfileAndImageUpload.Models.Contexts;
using _02_ProfileAndImageUpload.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace _02_ProfileAndImageUpload.Services
{
    public class ProfileHandler
    {
        private readonly IWebHostEnvironment _env;
        private readonly DataContext _context;
        private readonly LocalFileUpload _localFileUpload;
        private readonly CloudFileUpload _cloudFileUpload;

        public ProfileHandler(IWebHostEnvironment webHostEnvironment, DataContext context, LocalFileUpload localFileUpload, CloudFileUpload cloudFileUpload)
        {
            _env = webHostEnvironment;
            _context = context;
            _localFileUpload = localFileUpload;
            _cloudFileUpload = cloudFileUpload;
        }

        public async Task<string> UploadProfileImageAsync(IFormFile profileImage)
        {
            //return await _localFileUpload.UploadAsync(profileImage);
            return await _cloudFileUpload.UploadAsync(profileImage);

        }

        public async Task<Profile> GetProfileAsync(string username)
        {
            var identityUser = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (identityUser != null)
            {
                var profileEntity = await _context.UserProfiles.FirstOrDefaultAsync(x => x.UserId == identityUser.Id);
                if(profileEntity != null)
                {
                    var profile = new Profile
                    {
                        UserId = identityUser.Id,
                        FirstName = profileEntity.FirstName,
                        LastName = profileEntity.LastName,
                        Email = identityUser.Email!,
                        PhoneNumber = identityUser.PhoneNumber,
                        ImageName = profileEntity.ImageName
                    };

                    return profile;
                }
            }

            return null!;
        }
    }
}
