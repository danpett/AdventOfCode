using System;
using System.Collections.Generic;
using System.Linq;
using AoC;

namespace AoC2017.Day01
{
   public class Problem01 : IProblem
   {
      private readonly List<int> _input = new Data01().Part1().Select(c => int.Parse(c.ToString())).ToList();

      public string SolvePart1()
      {
         return GetSumOfPairs(i => _input[(i + 1) % _input.Count]);
      }

      public string SolvePart2()
      {
         return GetSumOfPairs(i => _input[(i + _input.Count / 2) % _input.Count]);
      }

      private string GetSumOfPairs(Func<int, int> pair)
      {
         return _input.Where((n, i) => n == pair(i)).Sum().ToString();
      }
   }
}