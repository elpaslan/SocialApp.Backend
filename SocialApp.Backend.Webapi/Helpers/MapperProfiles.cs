using AutoMapper;
using SocialApp.Backend.Webapi.Dtos;
using SocialApp.Backend.Webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp.Backend.Webapi.Helpers
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                //.ForMember(dest => dest.Image, opt =>
                //    opt.MapFrom(src => src.Images.FirstOrDefault(i => i.IsProfile)))
                .ForMember(dest => dest.ImageUrl, opt =>
                    opt.MapFrom(src => src.Images.FirstOrDefault(i => i.IsProfile).Name))

                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));

            CreateMap<User, UserForDetailsDto>()
                .ForMember(dest => dest.ProfileImageUrl, opt =>
                    opt.MapFrom(src => src.Images.FirstOrDefault(i => i.IsProfile).Name))

                .ForMember(dest => dest.Images, opt =>
                    opt.MapFrom(src => src.Images.Where(i => !i.IsProfile).ToList()))

                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));

            CreateMap<Image, ImagesForDetails>();

            CreateMap<UserForUpdateDto, User>();
        }
    }
}
