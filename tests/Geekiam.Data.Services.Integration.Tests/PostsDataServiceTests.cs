using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FizzWare.NBuilder;
using Geekiam.Data.Services.Integration.Tests.TestFixtures;
using Geekiam.Database;
using Geekiam.Domain.Mapping;
using Geekiam.Domain.Requests.Posts;
using Shouldly;
using Threenine.Data;
using Xunit;

namespace Geekiam.Data.Services.Integration.Tests;

[Collection(GlobalTestStrings.TestFixtureName)]
public class PostsDataServiceTests
{
    private readonly PostsDataService _classUnderTest;
    
    

    public PostsDataServiceTests(SqlLiteTestFixture fixture)
    {
        IUnitOfWork unitOfWork = new UnitOfWork<GeekContext>(fixture.Context);
        
        var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddProfile<PostsServiceMappingProfile>());
       mapperConfiguration.AssertConfigurationIsValid();
        var mapper = mapperConfiguration.CreateMapper();

        _classUnderTest = new PostsDataService(mapper, unitOfWork);
    }
    
    [Fact]
    public async Task ShouldInsertNewArticle()
    {
        var result = await _classUnderTest.Process(TestSubmission);
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task ShouldInsertNewArticleWithExistingTags()
    {
        var result = await _classUnderTest.Process(TestSubmissionWithExistingTags);
        result.ShouldNotBeNull();
    }

    private static Submission TestSubmission => Builder<Submission>.CreateNew()
            .With(x => x.Article = Builder<Detail>.CreateNew()
                .With(x => x.Title = $"Title{Guid.NewGuid().ToString()}")
                .With(x => x.Url = new Uri($"https://{Guid.NewGuid().ToString()}"))
            
                .Build())
            .With(x => x.Tags = new List<string>{ $"tag {Guid.NewGuid().ToString()}", $"tag {Guid.NewGuid().ToString()}"})
            .With(x => x.Categories = new List<string>{ $"category {Guid.NewGuid().ToString()}", $"category {Guid.NewGuid().ToString()}"})
            .Build();
    
      private static Submission TestSubmissionWithExistingTags => Builder<Submission>.CreateNew()
                .With(x => x.Article = Builder<Detail>.CreateNew()
                    .With(x => x.Title = $"Title{Guid.NewGuid().ToString()}")
                    .With(x => x.Url = new Uri($"https://{Guid.NewGuid().ToString()}"))
                
                    .Build())
                .With(x => x.Tags = new List<string>{ "tag B2b76c22-1C92-4159-8Fcb-416F1c5854b5"})
                .Build();
    
}