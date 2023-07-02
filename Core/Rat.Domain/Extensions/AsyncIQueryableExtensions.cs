using System.Linq.Expressions;
using System.Threading.Tasks;
using LinqToDB;

namespace System.Linq
{
    public static class AsyncIQueryableExtensions
    {
        public static Task<TSource> FirstOrDefaultAsync<TSource>(this IQueryable<TSource> source,
            Expression<Func<TSource, bool>> predicate = null)
        {
            return predicate == null ? AsyncExtensions.FirstOrDefaultAsync(source) : AsyncExtensions.FirstOrDefaultAsync(source, predicate);
        }
    }
}
