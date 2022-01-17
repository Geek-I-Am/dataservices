using System.Threading.Tasks;

namespace Geekiam.Data;

public interface IProcessDataService<in TAggregate, TResult> where TAggregate : class
    where TResult : class
{
    Task<TResult> Process(TAggregate aggregate);
    
}