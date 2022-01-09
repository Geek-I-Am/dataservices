using AutoMapper;
using FizzWare.NBuilder;
using Geekiam.Database.Entities;
using Geekiam.Domain.Requests.Categories;
using Shouldly;
using Xunit;

namespace Geekiam.Domain.Mapping.Tests;

public class CategoryMappingProfileTests
{
    private IMapper _mapper;

    public CategoryMappingProfileTests()
    {
        var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile<CategoryMappingProfile>());
        mapperConfiguration.AssertConfigurationIsValid();
        _mapper = mapperConfiguration.CreateMapper();
    }
    
    [Fact]
    public void ShouldMapTagToTags()
    {
        var result = _mapper.Map<Categories>(TestTag);
        
        result.Name.ShouldBeEquivalentTo(TestTag.Name);
        result.Permalink.ShouldBeEquivalentTo(TestTag.Permalink);
        result.Description.ShouldBeEquivalentTo(TestTag.Description);
        result.ShouldSatisfyAllConditions();
    }

    private Category TestTag => Builder<Category>
        .CreateNew()
        .Build();
}