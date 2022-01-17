using System.Linq.Expressions;

namespace Geekiam.Data.Services;

public abstract class Specification<TEntity> where TEntity : class
{
    public abstract Expression<Func<TEntity , bool>> ToExpression();
    
    public bool SatisfiedBy(TEntity entity)
    {
        var predicate = ToExpression().Compile();
        return predicate(entity);
    }
}