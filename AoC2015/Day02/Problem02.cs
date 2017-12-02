using System;
using System.Collections.Generic;
using System.Linq;
using AoC;

namespace AoC2015.Day02
{
   public class Problem02 : IProblem
   {
      private readonly List<Box> _presents = new Data02().Part1().Split(' ').Select(Box.Create).ToList();

      public string SolvePart1()
      {
         return SumProjection(RequriedWrapping);
      }

      public string SolvePart2()
      {
         return SumProjection(RequiredRibbon);
      }

      public string SumProjection(Func<Box, int> proj)
      {
         return _presents.Select(proj).Sum().ToString();
      }

      private static int RequriedWrapping(Box b)
      {
         return b.Area() + new List<int> { b.Length * b.Height, b.Length * b.Width, b.Width * b.Height }.Min();
      }

      private static int RequiredRibbon(Box b)
      {
         return b.Volume() + new List<int> { b.Height, b.Width, b.Length }.OrderBy(i => i).Take(2).Sum() * 2;
      }
   }

   public class Box
   {
      public Box(int width, int height, int length)
      {
         Width = width;
         Height = height;
         Length = length;
      }

      public int Width { get; }
      public int Height { get; }
      public int Length { get; }

      public static Box Create(string dimensions)
      {
         var d = dimensions.Split('x').ToList().Select(int.Parse).ToList();
         return new Box(d[0], d[1], d[2]);
      }

      public int Area()
      {
         return 2 * Width * Height + 2 * Width * Length + 2 * Height * Length;
      }

      public int Volume()
      {
         return Width * Height * Length;
      }
   }
}