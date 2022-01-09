using AutoMapper;
using Geekiam.Database.Entities;
using Geekiam.Domain.Requests.Tags;

namespace Geekiam.Domain.Mapping;

public class TagMappingProfile : Profile
{
    public TagMappingProfile()
    {
        CreateMap<Tag, Tags>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Permalink, opt => opt.MapFrom(src => src.Permalink))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Created, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Articles, opt => opt.Ignore())
            ;
    }
}