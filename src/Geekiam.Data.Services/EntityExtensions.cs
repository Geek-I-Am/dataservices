using Geekiam.Database.Entities;

namespace Geekiam.Data.Services;

public static class EntityExtensions
{
    public static Articles Created(this Articles articles)
    {
        articles.Created = DateTime.Now;
        return articles;
    }

    public static Tags Create(this Tags tags)
    {
        tags.Created = DateTime.Now;
        return tags;
    }
    
    public static Categories Create(this Categories category)
    {
        category.Created = DateTime.Now;
        return category;
    }
    
}