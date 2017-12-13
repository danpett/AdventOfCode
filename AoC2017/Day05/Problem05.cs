using System;
using System.Collections.Generic;
using AoC;

namespace AoC2017.Day05
{
   public class Problem05 : IProblem
   {
      public string SolvePart1()
      {
         Action<List<int>, int> offSetUpdate = (list, pos) => ++list[pos];
         return new Jumper(new Data05().Part1(), offSetUpdate).NumberOfStepsToExit().ToString();
      }

      public string SolvePart2()
      {
         Action<List<int>, int> offSetUpdate = (list, pos) => list[pos] += list[pos] < 3 ? 1 : -1; 
         return new Jumper(new Data05().Part1(), offSetUpdate).NumberOfStepsToExit().ToString();
      }
   }

   public class Jumper
   {
      private readonly List<int> _offsets;
      private readonly int _length;
      private readonly Action<List<int>, int> _offsetUpdate;

      private int _current;

      public Jumper(List<int> offsets, Action<List<int>, int> offsetUpdate)
      {
         _offsets = offsets;
         _offsetUpdate = offsetUpdate;
         _length = _offsets.Count;
      }

      public int NumberOfStepsToExit()
      {
         int steps = 1;

         while (true)
         {
            int next = _current + _offsets[_current];
            if (next < 0 || next >= _length) break;

            _offsetUpdate(_offsets, _current);
            _current = next;

            ++steps;
         }

         return steps;
      }
   }
}