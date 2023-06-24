

using System.Linq.Expressions;

namespace Core.Specefications
{
    public class BaseSpecefications<T> : ISpecefications<T>
    {
        public BaseSpecefications()
        {
        }

        public BaseSpecefications(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
       
        }

        public Expression<Func<T, bool>> Criteria { get;}

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        protected void AddInclude(Expression<Func<T,object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}