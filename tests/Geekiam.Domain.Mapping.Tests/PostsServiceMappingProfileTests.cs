using AutoMapper;
using FizzWare.NBuilder;
using Geekiam.Database.Entities;
using Geekiam.Domain.Requests.Posts;
using Shouldly;
using Xunit;

namespace Geekiam.Domain.Mapping.Tests;

public class PostsServiceMappingProfileTests
{
    private readonly IMapper _mapper;
    
    public PostsServiceMappingProfileTests()
    {
        var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile<PostsServiceMappingProfile>());
        mapperConfiguration.AssertConfigurationIsValid();
        _mapper = mapperConfiguration.CreateMapper();
    }
    
    [Fact]
    public void ShouldMapSubmissionToArticles()
    {
        var result = _mapper.Map<Articles>(TestSubmission);
        
        result.Author.ShouldBeEquivalentTo(TestSubmission.Article.Author);
        result.Published.ShouldBeEquivalentTo(TestSubmission.Article.Published);
        result.Summary.ShouldBeEquivalentTo(TestSubmission.Article.Summary);
        result.Title.ShouldBeEquivalentTo(TestSubmission.Article.Title);
        result.Url.ShouldBeEquivalentTo(TestSubmission.Article.Url);
        
    }

    private Submission TestSubmission => Builder<Submission>
        .CreateNew()
        .With(x => x.Article = Builder<Detail>.CreateNew().Build())
        .Build();
}