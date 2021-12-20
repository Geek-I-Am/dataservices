using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using AutoMapper;
using Geekiam.Database.Entities;
using Geekiam.Domain.Requests.Posts;
using Geekiam.Domain.Responses.Posts;
using Threenine.Data;
[assembly: InternalsVisibleTo("Geekiam.Data.Services.Unit.Tests")]
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

    internal void SaveTags(List<string> tags)
    {
        tags.ForEach(tag =>
        {
            var newtag = TransformTag(tag);
            var permalink = TransformPermalink(tag);
            
            

        });
    }

    internal string TransformTag(string tag)
    {
        var sb = new StringBuilder();

        var words = tag.Trim().Split(' ');

        if (words.Length < 1) return sb.Append(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tag.ToLower().Trim())).ToString();
        foreach (var word in words)
        {
            sb.Append(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.Trim().ToLower()));
        }

        return sb.ToString();
    }
    
    internal string TransformPermalink(string tag)
    {
        var sb = new StringBuilder();

        var words = tag.Trim().Split(' ');

        if (words.Length < 1) return sb.Append(tag.ToLower().Trim()).ToString();

        for (int i = 0; i < words.Length; i++)
        {
            if (i == words.Length)
            {
                sb.Append($"{words[i]}");
            }
            else
            {
                if(!string.IsNullOrWhiteSpace(words[i])) sb.Append($"{words[i]}-");
            }
        }

        return sb.ToString().TrimEnd('-');
    }
    
    
}