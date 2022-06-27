using System;
using System.Collections.Generic;
using System.Text;


namespace DelegatesAndLinq
{
    public static class EnumerableExtensions
    {
        public delegate bool SearchFunc<T>(T person);

        public static T GetFirstOrDefault<T>(this IEnumerable<T> source, SearchFunc<T> func)
        {
            foreach (var item in source)
                if (func(item))
                    return item;
            return default(T);
        }

        public static IEnumerable<T> Search<T>(this IEnumerable<T> source, SearchFunc<T> func)
        {
            IList<T> result = new List<T>();
            foreach (T item in source)
                if (func(item))
                    result.Add(item);
            return result;
        }
    }
}
