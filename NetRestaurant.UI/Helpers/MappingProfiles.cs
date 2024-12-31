﻿using AutoMapper;
using NetRestaurant.Core.Entities;
using NetRestaurant.UI.Areas.Admin.ViewModels;
using NetRestaurant.UI.ViewModels;

namespace NetRestaurant.UI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {

            CreateMap<UserVM, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));

            CreateMap<User, UserVM>();
            CreateMap<Category, CategoryVM>().ReverseMap();

            CreateMap<Dish, DishVM>().ReverseMap();
        }
    }
}
