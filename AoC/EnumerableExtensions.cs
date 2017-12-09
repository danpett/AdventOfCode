using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC
{
   public static class EnumerableExtensions
   {
      public static IEnumerable<T> Every<T>(this IEnumerable<T> @this, int n)
      {
         return @this.Where((t, i) => i % n == 0);
      }

      public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
      {
         foreach (var t in @this) action(t);
      }

      public static void ForEach<T>(this IEnumerable<T> @this, Action<int, T> action)
      {
         int i = 0;
         foreach (var t in @this) action(i++, t);
      }

      public static bool Unique<T>(this IEnumerable<T> @this)
      {
         return @this.GroupBy(v => v).All(c => c.Count() == 1);
      }

      public static IEnumerable<Tuple<T, T>> WhereIntersect<T>(this List<T> @this, Func<T, T, bool> pred)
      {
         for (int i = 0; i < @this.Count - 1; ++i)
         {
            for (int j = i + 1; j < @this.Count; ++j)
            {
               if (pred(@this[i], @this[j])) yield return new Tuple<T, T>(@this[i], @this[j]);
            }
         }
      }

      public static IEnumerable<List<T>> Split<T>(this List<T> @this, int chunkSize)
      {
         for (int i = 0; i < @this.Count; i += chunkSize) yield return @this.Skip(i).Take(chunkSize).ToList();
      }
   }
}