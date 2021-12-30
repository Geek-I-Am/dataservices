using AutoMapper;
using Geekiam.Database.Entities;
using Geekiam.Domain.Requests.Posts;

namespace Geekiam.Domain.Mapping;

public class PostsServiceMappingProfile : Profile
{
    public PostsServiceMappingProfile()
    {
        CreateMap<Submission, Articles>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Content.Author))
            .ForMember(dest => dest.Published, opt => opt.MapFrom(src => src.Content.Published))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Article.Title))
            .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Content.Summary))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Article.Url))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Created, opt => opt.Ignore());
        
    }
}