using System;
using System.Linq;
using AoC;
using AoC2017.Day01;
using AoC2017.Day02;

namespace AoC2017
{
   public class Program
   {
      public static void Main(string[] args)
      {
         System.Reflection.Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IProblem)))
            .ForEach(ip => Solver.Solve((IProblem)Activator.CreateInstance(ip)));

         // Solver.Solve(new Problem01());
         // Solver.Solve(new Problem02());
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