using System.Linq;
using AutoMapper;
using DatingApp.Api.Dtos;
using DatingApp.Api.Models;

namespace DatingApp.Api.Helpers
{
    public class AutomapperProfiles  : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                            .ForMember(m => m.PhotoUrl, opt => {
                                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                            })
                            .ForMember(m => m.Age, opt => opt.ResolveUsing(d => d.DateOfBirth.ToAge()));
            CreateMap<User, UserForDetailDto>()
                                .ForMember(m => m.PhotoUrl, opt => {
                                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                            })
                                .ForMember(m => m.Age, opt => opt.ResolveUsing(d => d.DateOfBirth.ToAge()));
            CreateMap<User, UserDto>();
            CreateMap<User, UserForUpdateDto>();
            CreateMap<Photo, PhotoDto>();
        }
    }
}