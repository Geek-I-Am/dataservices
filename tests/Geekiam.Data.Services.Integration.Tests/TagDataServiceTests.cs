using System.Threading.Tasks;
using FizzWare.NBuilder;
using Geekiam.Data.Services.Integration.Tests.TestFixtures;
using Geekiam.Database;
using Geekiam.Domain.Requests.Tags;
using Shouldly;
using Threenine.Data;
using Xunit;

namespace Geekiam.Data.Services.Integration.Tests;

[Collection(GlobalTestStrings.TestFixtureName)]
public class TagDataServiceTests
{
    private readonly TagDataService _classUnderTest;

    public TagDataServiceTests(SqlLiteTestFixture fixture)
    {
        IUnitOfWork unitOfWork = new UnitOfWork<GeekiamContext>(fixture.Context);
        _classUnderTest = new TagDataService(unitOfWork);
    }
    
    [Fact]
    public async Task ShouldInsertNewTag()
    {
        var result = await _classUnderTest.Process(TestAggregate);
        result.ShouldNotBeNull();
    }
    
    private Tag TestAggregate => Builder<Tag>
        .CreateNew()
        .Build();
}