using System;
using System.Collections.Generic;
using System.Linq;
using AndcultureCode.CSharp.Extensions;

namespace AndcultureCode.CSharp.Data.SqlServer.Extensions
{
    // TODO: Move to AndcultureCode.CSharp.Extensions
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Returns a distinct enumerable by a specific property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> property)
            => source.GroupBy(property).Select(x => x.First());

        /// <summary>
        /// Returns a distinct list by a specific property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static IEnumerable<T> DistinctBy<T, TKey>(this List<T> source, Func<T, TKey> property)
            => source.GroupBy(property).Select(x => x.First());
    }
}
