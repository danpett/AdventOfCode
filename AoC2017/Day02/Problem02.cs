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
         return _input.Split(16).Select(MinMaxDiff).Sum().ToString();
      }

      public string SolvePart2()
      {
         return _input.Split(16).Select(Multiple).Sum().ToString();
      }

      private static int MinMaxDiff(IEnumerable<int> e)
      {
         var l = e.ToList();
         return l.Max() - l.Min();
      }

      private static int Multiple(List<int> l)
      {
         var t = l.WhereIntersect((a, b) => a % b == 0 || b % a == 0).Single();
         return t.Item1 > t.Item2 ? t.Item1 / t.Item2 : t.Item2 / t.Item1;
      }
   }
}