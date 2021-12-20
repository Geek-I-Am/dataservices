using System;
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

    private static Submission TestSubmission => Builder<Submission>.CreateNew()
            .With(x => x.Article = Builder<Detail>.CreateNew()
                .With(x => x.Title = $"Title{Guid.NewGuid().ToString()}")
                .With(x => x.Url = new Uri($"https://{Guid.NewGuid().ToString()}"))
                .Build())
            .Build();
    
}