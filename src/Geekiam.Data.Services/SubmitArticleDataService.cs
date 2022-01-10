using System.Runtime.CompilerServices;
using AutoMapper;
using Geekiam.Database.Entities;
using Geekiam.Domain.Mapping;
using Geekiam.Domain.Requests.Posts;
using Geekiam.Domain.Responses.Posts;
using Threenine.Data;
using Article = Geekiam.Domain.Responses.Posts.Article;

[assembly: InternalsVisibleTo("Geekiam.Data.Services.Unit.Tests")]

namespace Geekiam.Data.Services;

public class SubmitArticleDataService : BaseDataService, IDataService<Submission, Submitted>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public SubmitArticleDataService(IUnitOfWork unitOfWork)
    {
        var mapperConfiguration =
            new MapperConfiguration(configuration => configuration.AddProfile<PostsServiceMappingProfile>());
        mapperConfiguration.AssertConfigurationIsValid();
        _mapper = mapperConfiguration.CreateMapper();
        _unitOfWork = unitOfWork;
    }

    public async Task<Submitted> Process(Submission aggregate)
    {
        var article = _mapper.Map<Articles>(aggregate);
        var articlesRepository = _unitOfWork.GetRepository<Articles>();
        articlesRepository.Insert(article.Created());
        await _unitOfWork.CommitAsync();
        if (aggregate.Metadata.Tags != null) SaveTags(aggregate.Metadata.Tags.ToList(), article.Id);
        if (aggregate.Metadata.Categories != null) SaveCategories(aggregate.Metadata.Categories.ToList(), article.Id);

        return new Submitted { Article = new Article(article.Title, new Uri(article.Url)) };
    }

    private void SaveCategories(List<string> categories, Guid articleId)
    {
        var categoriesRepository = _unitOfWork.GetRepository<Categories>();
       
        categories.ForEach(category =>
        {
            var categoryName = TransformCategory(category);
            var categoryLink = TransformPermalink(category);

            var newCat = new
                Categories { Name = categoryName, Permalink = categoryLink, Created = DateTime.Now };

            var articleCategory = categoriesRepository.InsertNotExists(x => x.Name == categoryName, newCat);
            _unitOfWork.Commit();

            var articleCategoriesRepository = _unitOfWork.GetRepository<ArticleCategories>();
            articleCategoriesRepository.Insert(new ArticleCategories()
                { ArticleId = articleId, CategoryId = articleCategory.Id });
            
            _unitOfWork.Commit();
        });
    }

    private void SaveTags(List<string> tags, Guid articleId)
    {
        var tagsRepository = _unitOfWork.GetRepository<Tags>();
     
        tags.ForEach(tag =>
        {
            var tagName = TransformTag(tag);
            var tagLink = TransformPermalink(tag);

            var newTag = new
                Tags { Name = tagName, Permalink = tagLink, Created = DateTime.Now };

            var articleTag = tagsRepository.InsertNotExists(x => x.Name == tagName, newTag);
            _unitOfWork.Commit();
            var articleCategoriesRepository = _unitOfWork.GetRepository<ArticleTags>();
            articleCategoriesRepository.Insert(new ArticleTags()
                { ArticleId = articleId, TagId = articleTag.Id });
         
            _unitOfWork.Commit();
        });
    }

  
    
}