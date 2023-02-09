using AutoMapper;
using WebApp.Models;
using WebApp.Models.Entities;

namespace WebApp.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<NavLinkEntity, NavLinkModel>().ReverseMap();
            CreateMap<ImageEntity, ImageModel>().ReverseMap();
            CreateMap<ShowcaseEntity, ShowcaseModel>().ReverseMap();
            CreateMap<ProductReviewModel, ProductReviewEntity>().ReverseMap();
        }
    }
}
