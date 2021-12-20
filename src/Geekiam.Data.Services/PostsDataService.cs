using AutoMapper;
using Geekiam.Database.Entities;
using Geekiam.Domain.Requests.Posts;
using Geekiam.Domain.Responses.Posts;
using Threenine.Data;

namespace Geekiam.Data.Services;

public class PostsDataService : IDataService<Submission, Submitted>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PostsDataService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<Submitted> Process(Submission aggregate)
    {
        var article = _mapper.Map<Articles>(aggregate.Article);
        var articlesRepository = _unitOfWork.GetRepository<Articles>();
        articlesRepository.Insert(article);
        await _unitOfWork.CommitAsync();
        return new Submitted() { Article = new Article(article.Title, new Uri(article.Url)) };
    }
}