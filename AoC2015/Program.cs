using System;
using System.Diagnostics;
using AoC;
using AoC2015.Day01;
using AoC2015.Day02;
using AoC2015.Day03;
using AoC2015.Day04;

namespace AoC2015
{
   public class Program
   {
      public static void Main(string[] args)
      {
         Solver.Solve(new Problem01());
         Solver.Solve(new Problem02());
         Solver.Solve(new Problem03());
         var sw = new Stopwatch();
         sw.Start();
         Solver.Solve(new Problem04());
         Console.WriteLine(sw.ElapsedMilliseconds);

         Console.Read();
      }
   }

   public static class Solver
   {
      public static void Solve(IProblem problem)
      {
         Console.WriteLine(problem.GetType().Name);
         Console.WriteLine("========================");
         Console.WriteLine("Part 1: " + problem.SolvePart1());
         Console.WriteLine("Part 2: " + problem.SolvePart2());
      }
   }
}