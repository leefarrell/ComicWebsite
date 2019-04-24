using System.Linq;
using AutoMapper;
using ComicWebsite.API.Dtos;
using ComicWebsite.API.Models;

namespace ComicWebsite.API.Helpers
{
    public class AMProfile : Profile
    {
        public AMProfile()
        {
            CreateMap<Comic, ComicDto>();
            CreateMap<Comic, ComicDetailsDto>();
            CreateMap<User, UserDto>().ForMember(dest => dest.PhotoUrl, opt => { opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);});
            CreateMap<User, UserDetailsDto>().ForMember(dest => dest.PhotoUrl, opt => { opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);});
            CreateMap<Photo, PhotoDetailsDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}