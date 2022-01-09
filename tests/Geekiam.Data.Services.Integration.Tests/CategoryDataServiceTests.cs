using System.Threading.Tasks;
using FizzWare.NBuilder;
using Geekiam.Data.Services.Integration.Tests.TestFixtures;
using Geekiam.Database;
using Geekiam.Domain.Requests.Categories;
using Shouldly;
using Threenine.Data;
using Xunit;

namespace Geekiam.Data.Services.Integration.Tests;

[Collection(GlobalTestStrings.TestFixtureName)]
public class CategoryDataServiceTests
{
    private readonly CategoryDataService _classUnderTest;

    public CategoryDataServiceTests(SqlLiteTestFixture fixture)
    {
        IUnitOfWork unitOfWork = new UnitOfWork<GeekiamContext>(fixture.Context);
        _classUnderTest = new CategoryDataService(unitOfWork);
    }
    
    [Fact]
    public async Task ShouldInsertNewCategory()
    {
        var result = await _classUnderTest.Process(TestAggregate);
        result.ShouldNotBeNull();
    }
    
    private Category TestAggregate => Builder<Category>
        .CreateNew()
        .Build();
}