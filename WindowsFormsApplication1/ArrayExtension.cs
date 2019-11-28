
using System;
using System.Collections.Generic;
namespace WindowsFormsApplication1
{
    public static class ArrayExtensuin
    {
        public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null) throw Error.ArgumentNull("source");
            return SkipIterator<TSource>(source, count);
        }

        static IEnumerable<TSource> SkipIterator<TSource>(IEnumerable<TSource> source, int count)
        {
            using (IEnumerator<TSource> e = source.GetEnumerator())
            {
                while (count > 0 && e.MoveNext()) count--;
                if (count <= 0)
                {
                    while (e.MoveNext()) yield return e.Current;
                }
            }
        }
        
    }
}