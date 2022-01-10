using AutoMapper;
using Geekiam.Database.Entities;
using Geekiam.Domain.Requests.Posts;

namespace Geekiam.Domain.Mapping;

public class PostsServiceMappingProfile : Profile
{
    public PostsServiceMappingProfile()
    {
        CreateMap<Submission, Articles>()
            .ForMember(dest => dest.Published, opt => opt.MapFrom(src => src.Body.Published))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Article.Title))
            .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Body.Summary))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Article.Url))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Body.Content))
            .ForMember(dest => dest.Published, opt => opt.MapFrom(src => src.Body.Published))
            .ForMember(dest => dest.ArticleTags, opt => opt.Ignore())
            .ForMember(dest => dest.ArticleCategories, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Created, opt => opt.Ignore());
        
    }
}