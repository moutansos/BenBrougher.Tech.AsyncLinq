using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenBrougher.Tech.AsyncLinq
{
    /// <summary>
    /// Provides extension methods for working with asynchronous LINQ operations.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Projects each element of a sequence to a new form asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <typeparam name="R">The type of the value returned by the transform function.</typeparam>
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="func">An asynchronous transform function to apply to each element.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IEnumerable{R}"/> whose elements are the result of invoking the transform function on each element of source.</returns>
        /// <exception cref="ArgumentNullException">source or func is null.</exception>
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

        /// <summary>
        /// Projects each element of a sequence to an <see cref="IEnumerable{R}"/> and flattens the resulting sequences into one sequence asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <typeparam name="R">The type of the elements of the sequence returned by the selector function.</typeparam>
        /// <param name="source">A sequence of values to project.</param>
        /// <param name="func">An asynchronous transform function to apply to each element.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IEnumerable{R}"/> whose elements are the result of invoking the one-to-many transform function on each element of the input sequence.</returns>
        /// <exception cref="ArgumentNullException">source or func is null.</exception>
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
