using AutoMapper;
using Geekiam.Database.Entities;
using Geekiam.Domain.Requests.Categories;

namespace Geekiam.Domain.Mapping;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, Categories>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Permalink, opt => opt.MapFrom(src => src.Permalink))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Created, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ArticleCategories, opt => opt.Ignore())
            ;
    }
    
}