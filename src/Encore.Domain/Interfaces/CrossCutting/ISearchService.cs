using System.Linq.Expressions;

namespace Encore.Domain.Interfaces.CrossCutting
{
    public interface ISearchService<TSearch>
    {
        Expression<Func<TSearch, bool>> AndAlso(Expression<Func<TSearch, bool>> left, Expression<Func<TSearch, bool>> right);
    }
}
