using System;
using System.Collections.Generic;
using System.Linq;
using AoC;

namespace AoC2015.Day01
{
   public class Problem01 : IProblem
   {
      private const char Up = '(';
      private const char Down = ')';
      private static readonly IData Data = new Data01();
      private readonly List<char> _input = Data.Part1().ToList();

      public string SolvePart1()
      {
         int floor = _input.Count(c => c == Up) - _input.Count(c => c == Down);
         return floor.ToString();
      }

      public string SolvePart2()
      {
         const int AdjustForZeroBasedIndexing = 1;
         var floor = 0;
         Func<char, bool> pred = c =>
         {
            floor += c == Up ? 1 : -1;
            return floor >= 0;
         };
         return (_input.TakeWhile(pred).Count() + AdjustForZeroBasedIndexing).ToString();
      }
   }
}