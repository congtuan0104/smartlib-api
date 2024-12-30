using AutoMapper;
using SmartLibApi.Models.Entity;
using SmartLibApi.Models.Request;
using SmartLibApi.Models.Response;

namespace SmartLibApi.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AuthorReq.NewAuthor, Author>();

        CreateMap<Author, AuthorDTO>().ReverseMap();
        
        CreateMap<AuthReq.RegisterUserDto, User>();
    }
}