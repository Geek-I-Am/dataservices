using System;
using AutoMapper;
using FizzWare.NBuilder;
using Geekiam.Database.Entities;
using Geekiam.Domain.Requests.Tags;
using Shouldly;
using Xunit;

namespace Geekiam.Domain.Mapping.Tests;

public class TagMappingProfileTests
{
    private IMapper _mapper;

    public TagMappingProfileTests()
    {
        var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile<TagMappingProfile>());
        mapperConfiguration.AssertConfigurationIsValid();
        _mapper = mapperConfiguration.CreateMapper();
    }
    

    [Fact]
    public void ShouldMapTagToTags()
    {
        var result = _mapper.Map<Tags>(TestTag);
        
        result.Name.ShouldBeEquivalentTo(TestTag.Name);
        result.Permalink.ShouldBeEquivalentTo(TestTag.Permalink);
        result.Description.ShouldBeEquivalentTo(TestTag.Description);
        result.ShouldSatisfyAllConditions();
    }

    private Tag TestTag => Builder<Tag>
        .CreateNew()
        .Build();
}