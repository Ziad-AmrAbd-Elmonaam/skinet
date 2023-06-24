
using System.Linq.Expressions;


namespace Core.Specefications
{
    public interface ISpecefications<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
         
    }
}