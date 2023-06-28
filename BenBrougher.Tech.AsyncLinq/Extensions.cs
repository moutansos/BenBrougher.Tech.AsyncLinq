using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenBrougher.Tech.AsyncLinq
{
    public static class Extensions
    {
        public static async Task<IEnumerable<R>> SelectAsync<T, R>(this IEnumerable<T> source, Func<T, Task<R>> func)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (func == null)
                throw new ArgumentNullException(nameof(func));

            IEnumerable<R> results = Enumerable.Empty<R>();
            foreach (var item in source)
                results = results.Append(await func(item));

            return results.ToArray();
        }

        public static async Task<IEnumerable<R>> SelectManyAsync<T, R>(this IEnumerable<T> source, Func<T, Task<IEnumerable<R>>> func)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (func == null)
                throw new ArgumentNullException(nameof(func));

            IEnumerable<R> results = Enumerable.Empty<R>();
            foreach (var item in source)
                results = results.Concat(await func(item));

            return results.ToArray();
        }
    }
}
