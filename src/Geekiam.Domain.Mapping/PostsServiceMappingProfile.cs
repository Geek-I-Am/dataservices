using AutoMapper;
using Geekiam.Database.Entities;
using Geekiam.Domain.Requests.Posts;

namespace Geekiam.Domain.Mapping;

public class PostsServiceMappingProfile : Profile
{
    public PostsServiceMappingProfile()
    {
        CreateMap<Detail, Articles>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
            .ForMember(dest => dest.Published, opt => opt.MapFrom(src => src.Published))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Created, opt => opt.Ignore());
        
    }
}