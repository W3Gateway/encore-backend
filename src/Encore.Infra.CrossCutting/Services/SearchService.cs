using Encore.Domain.Interfaces.CrossCutting;
using System.Linq.Expressions;

namespace Encore.Infra.CrossCutting.Services
{
    public class SearchService<TSearch> : ISearchService<TSearch>
    {
        public Expression<Func<TSearch, bool>> AndAlso(Expression<Func<TSearch, bool>> left, Expression<Func<TSearch, bool>> right)
        {
            var param = Expression.Parameter(typeof(TSearch));
            var body = Expression.AndAlso(
                Expression.Invoke(left, param),
                Expression.Invoke(right, param)
            );

            return Expression.Lambda<Func<TSearch, bool>>(body, param);
        }
    }
}
