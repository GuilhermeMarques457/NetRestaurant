using AutoMapper;
using NetRestaurant.Core.Entities;
using NetRestaurant.UI.Areas.Admin.ViewModels;

namespace NetRestaurant.UI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {

            CreateMap<UserVM, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));

            CreateMap<User, UserVM>();
        }
    }
}
