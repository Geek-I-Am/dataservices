using Geekiam.Database.Entities;

namespace Geekiam.Data.Services;

public static class EntityExtensions
{
    public static Articles Created(this Articles articles)
    {
        articles.Created = DateTime.Now;
        return articles;
    }
    
}