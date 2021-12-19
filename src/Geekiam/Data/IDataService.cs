namespace Geekiam.Data;

public interface IDataService<in TAggregate, TResult> where TAggregate : class
    where TResult : class
{
    Task<TResult> Process(TAggregate aggregate);
}