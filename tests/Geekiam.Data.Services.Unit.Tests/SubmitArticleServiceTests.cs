using Moq;
using Shouldly;
using Threenine.Data;
using Xunit;

namespace Geekiam.Data.Services.Unit.Tests;

public class SubmitArticleServiceTests
{
    private SubmitArticleDataService _classUnderTest;
    private Mock<IUnitOfWork> _unitOfWork = new();

    public SubmitArticleServiceTests()
    {
        _classUnderTest = new SubmitArticleDataService(_unitOfWork.Object);
    }
    
    [Theory]
    [InlineData("poo poo", "PooPoo")]
    [InlineData("software development", "SoftwareDevelopment")]
    [InlineData("geek i am", "GeekIAm")]
    [InlineData("three  little  birds", "ThreeLittleBirds")]
    [InlineData("this     should not     have      spaces", "ThisShouldNotHaveSpaces")]
    public void ShouldTransformTags(string testString, string expected)
    {
        var result = SubmitArticleDataService.TransformTag(testString);
        
        result.ShouldBeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("poo poo", "poo-poo")]
    [InlineData("software development", "software-development")]
    [InlineData("geek i am", "geek-i-am")]
    [InlineData("three  little  birds", "three-little-birds")]
    public void ShouldTransformPermalink(string testString, string expected)
    {
        var result = SubmitArticleDataService.TransformPermalink(testString);
        
        result.ShouldBeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("poo poo", "Poo Poo")]
    [InlineData("software development", "Software Development")]
    [InlineData("geek i am", "Geek I Am")]
    [InlineData("three  little  birds", "Three Little Birds")]
    public void ShouldTransformCategories(string testString, string expected)
    {
        var result = SubmitArticleDataService.TransformCategory(testString);
        
        result.ShouldBeEquivalentTo(expected);
    }
}