using System;
using System.Collections.Generic;

namespace RefaceCore.Modularization
{
    public static class CollectionExtension
    {
        public static int IndexOf<T>(this IEnumerable<T> list, Func<T, bool> condition)
        {
            int i = 0;
            foreach (var item in list)
            {
                if (condition(item))
                    return i;
                i++;
            }
            return -1;
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T> handler)
        {
            foreach (T item in list)
                handler(item);
        }
        public static void AddMany<T>(this ICollection<T> list, IEnumerable<T> items)
        {
            foreach (T item in items)
                list.Add(item);
        }
    }
}
