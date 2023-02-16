using AutoMapper;
using Fixxo.Models.Forms;
using Fixxo.Models.Identity;

namespace Fixxo.Services
{
    public class AutoMapperServices: Profile
    {
        public AutoMapperServices()
        {
            CreateMap<RegisterForm, AppUser>().ReverseMap();
        }
    }
}
