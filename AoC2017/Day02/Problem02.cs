using System;
using System.Collections.Generic;
using System.Linq;
using AoC;

namespace AoC2017.Day02
{
   public class Problem02 : IProblem
   {
      private readonly List<int> _input = new Data02().Part1().Split(' ').Select(int.Parse).ToList();

      public string SolvePart1()
      {
         return Split(_input, 16).Select(MinMaxDiff).Sum().ToString();
      }

      public string SolvePart2()
      {
         return Split(_input, 16).Select(FirstMultiple).Sum().ToString();
      }

      private int MinMaxDiff(IEnumerable<int> e)
      {
         var l = e.ToList();
         return l.Max() - l.Min();
      }

      private int FirstMultiple(List<int> l)
      {
         for (int i = 0; i < l.Count - 1; ++i)
         {
            for (int j = i + 1; j < l.Count; ++j)
            {
               if (l[i] % l[j] == 0) return l[i] / l[j];
               if (l[j] % l[i] == 0) return l[j] / l[i];
            }
         }

         throw new ArgumentException("Enumerable does not contain any numbers a and b where a is a multiple of b.");
      }

      private IEnumerable<List<T>> Split<T>(List<T> l, int n)
      {
         for (int i = 0; i < l.Count; i += n)
         {
            yield return l.Skip(i).Take(n).ToList();
         }
      }
   }
}