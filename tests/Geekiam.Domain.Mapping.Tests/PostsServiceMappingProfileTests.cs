using System;
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
        
        result.Author.ShouldBeEquivalentTo(TestSubmission.Content.Author);
        result.Published.ShouldBeEquivalentTo(TestSubmission.Content.Published);
        result.Summary.ShouldBeEquivalentTo(TestSubmission.Content.Summary);
        result.Title.ShouldBeEquivalentTo(TestSubmission.Article.Title);
        result.Url.ShouldBeEquivalentTo(TestSubmission.Article.Url.ToString());
        
    }

    private Submission TestSubmission => Builder<Submission>
        .CreateNew()
        .With(x => x.Article = new Article("title1",new Uri("https://test")))
        .With(x => x.Content = Builder<Content>.CreateNew().Build())
        .With(x => x.Metadata = Builder<Metadata>.CreateNew().Build())
        .Build();
}