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
   }
}