using Geekiam.Domain.Requests.Posts;
using Geekiam.Domain.Responses.Posts;

namespace Geekiam.Data.Services;

public class PostsDataService : IDataService<Submission, Submitted>
{
    public Task<Submitted> Process(Submission aggregate)
    {
        throw new NotImplementedException();
    }
}