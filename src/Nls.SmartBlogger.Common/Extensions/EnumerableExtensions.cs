using System;
using System.Collections.Generic;
using System.Linq;

namespace Nls.SmartBlogger.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> predicate)
        {
            if (source == null || source.Any() == false || condition == false)
            {
                return null;
            }

            return source.Where(predicate);
        }
    }
}
