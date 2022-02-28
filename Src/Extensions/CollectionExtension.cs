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

        public static IDictionary<TKey, TValue> ToMap<TItem, TKey, TValue>(this IEnumerable<TItem> list, Func<TItem, TKey> keySelector, Func<TItem, TValue> valueSelector)
        {
            IDictionary<TKey, TValue> result = new Dictionary<TKey, TValue>();
            list.ForEach(item =>
            {
                result[keySelector(item)] = valueSelector(item);
            });
            return result;
        }
    }
}
