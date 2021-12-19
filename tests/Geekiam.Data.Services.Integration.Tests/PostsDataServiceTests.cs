using Geek.Database;
using Geekiam.Data.Services.Integration.Tests.TestFixtures;
using Geekiam.Domain.Responses.Posts;
using Shouldly;
using Threenine.Data;
using Xunit;

namespace Geekiam.Data.Services.Integration.Tests;

[Collection(GlobalTestStrings.TestFixtureName)]
public class PostsDataServiceTests
{
    private readonly SqlLiteTestFixture _fixture;

    private readonly IUnitOfWork _unitOfWork;
    

    public PostsDataServiceTests(SqlLiteTestFixture fixture)
    {
        _fixture = fixture;
        _unitOfWork = new UnitOfWork<GeekContext>(_fixture.Context);
    }
    [Fact]
    public void Test1()
    {
        var repo = _unitOfWork.GetRepository<Article>();

        repo.ShouldNotBeNull();

    }
}