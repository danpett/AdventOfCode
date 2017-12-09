using System.Collections.Generic;
using System.Linq;
using AoC;

namespace AoC2017.Day04
{
   public class Problem04 : IProblem
   {
      private readonly List<string> _input = new Data04().Part1().ToList();

      public string SolvePart1()
      {
         return _input.Count(HasUniqueWords).ToString();
      }

      public string SolvePart2()
      {
         return _input.Count(HasNoAnagrams).ToString();
      }

      private static bool HasUniqueWords(string passPhrase)
      {
         return passPhrase.Split(' ').Unique();
      }

      private static bool HasNoAnagrams(string passPhrase)
      {
         return !passPhrase.Split(' ').ToList().WhereIntersect(IsAnagram).Any();
      }

      private static bool IsAnagram(string s1, string s2)
      {
         return s1.OrderBy(c => c).SequenceEqual(s2.OrderBy(c => c));
      }
   }
}