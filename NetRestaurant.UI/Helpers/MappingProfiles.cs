using AutoMapper;
using NetRestaurant.Core.Entities;
using NetRestaurant.UI.Areas.Admin.ViewModels;

namespace NetRestaurant.UI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {

            CreateMap<User, UserVM>().ReverseMap();
        }
    }
}
