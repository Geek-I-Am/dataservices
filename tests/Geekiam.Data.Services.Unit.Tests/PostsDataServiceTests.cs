using AutoMapper;
using Moq;
using Shouldly;
using Threenine.Data;
using Xunit;

namespace Geekiam.Data.Services.Unit.Tests;

public class PostsDataServiceTests
{
    private PostsDataService _classUnderTest;
    private Mock<IUnitOfWork> _unitOfWork = new();

    public PostsDataServiceTests()
    {
        _classUnderTest = new PostsDataService(_unitOfWork.Object);
    }
    
    [Theory]
    [InlineData("poo poo", "PooPoo")]
    [InlineData("software development", "SoftwareDevelopment")]
    [InlineData("geek i am", "GeekIAm")]
    [InlineData("three  little  birds", "ThreeLittleBirds")]
    public void ShouldTransformTags(string testString, string expected)
    {
        var result = PostsDataService.TransformTag(testString);
        
        result.ShouldBeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("poo poo", "poo-poo")]
    [InlineData("software development", "software-development")]
    [InlineData("geek i am", "geek-i-am")]
    [InlineData("three  little  birds", "three-little-birds")]
    public void ShouldTransformPermalink(string testString, string expected)
    {
        var result = PostsDataService.TransformPermalink(testString);
        
        result.ShouldBeEquivalentTo(expected);
    }
}