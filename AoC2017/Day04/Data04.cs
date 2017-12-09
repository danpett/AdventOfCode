using System.Collections.Generic;
using System.IO;

namespace AoC2017.Day04
{
   public class Data04
   {
      public IEnumerable<string> Part1()
      {
         var path = @"C:\Users\Administrator\Source\Repos\AdventOfCode\AoC2017\Day04\Input04.txt";
         return GetFileByLine(path);
      }

      public string Part2()
      {
         return string.Empty;
      }

      private static IEnumerable<string> GetFileByLine(string path)
      {
         using (var file = new StreamReader(path))
         {
            string line;
            while ((line = file.ReadLine()) != null)
            {
               yield return line;
            }
         }
      }
   }
}