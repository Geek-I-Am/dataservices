using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FizzWare.NBuilder;
using Geekiam.Data.Services.Integration.Tests.TestFixtures;
using Geekiam.Data.Services.Posts;
using Geekiam.Database;
using Geekiam.Domain.Mapping;
using Geekiam.Domain.Requests.Posts;
using Shouldly;
using Threenine.Data;
using Xunit;

namespace Geekiam.Data.Services.Integration.Tests;

[Collection(GlobalTestStrings.TestFixtureName)]
public class SubmitArticleDataServiceTests
{
    private readonly SubmitArticleProcessDataService _classUnderTest;

    public SubmitArticleDataServiceTests(SqlLiteTestFixture fixture)
    {
        IUnitOfWork unitOfWork = new UnitOfWork<GeekiamContext>(fixture.Context);
        _classUnderTest = new SubmitArticleProcessDataService(unitOfWork);
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
        var result = await _classUnderTest.Process(TestSubmission);
        result.ShouldNotBeNull();
    }

    private static Submission TestSubmission => Builder<Submission>.CreateNew()
            .With(x => x.Article = Builder<Article>.CreateNew().With(x => x.Url = new Uri($"https://{Guid.NewGuid().ToString()}.com"))
                .Build())
            .With(x => x.Body = Builder<Body>.CreateNew().Build())
            .With(x => x.Metadata = Builder<Metadata>.CreateNew()
                .With(x => x.Categories = new List<string>(){"software development" , "development"})
                .With(x => x.Tags = new List<string>(){"bitcoin", "c-sharp"})
                .Build())
            .Build();
    
    
}