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
public class SubmitArticleDataServiceTests
{
    private readonly SubmitArticleDataService _classUnderTest;

    public SubmitArticleDataServiceTests(SqlLiteTestFixture fixture)
    {
        IUnitOfWork unitOfWork = new UnitOfWork<GeekiamContext>(fixture.Context);
        _classUnderTest = new SubmitArticleDataService(unitOfWork);
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
            .With(x => x.Article = Builder<Article>.CreateNew()
                .Build())
            .With(x => x.Metadata.Tags = new List<string>{ $"tag {Guid.NewGuid().ToString()}", $"tag {Guid.NewGuid().ToString()}"})
            .With(x => x.Metadata.Categories = new List<string>{ $"category {Guid.NewGuid().ToString()}", $"category {Guid.NewGuid().ToString()}"})
            .Build();
    
      private static Submission TestSubmissionWithExistingTags => Builder<Submission>.CreateNew()
                .With(x => x.Article = Builder<Article>.CreateNew()
                   
                    .Build())
                .With(x => x.Metadata.Tags = new List<string>{ "tag B2b76c22-1C92-4159-8Fcb-416F1c5854b5"})
                .Build();
    
}