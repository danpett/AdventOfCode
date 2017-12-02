using System.Security.Cryptography;
using System.Text;
using AoC;

namespace AoC2015.Day04
{
   public class Problem04 : IProblem
   {
      private readonly string _secret = new Data04().Part1();

      public string SolvePart1()
      {
         return HashThatStartsWithNZeros(5);
      }

      public string SolvePart2()
      {
         return HashThatStartsWithNZeros(6);
      }

      private string HashThatStartsWithNZeros(int leadingZerosCount)
      {
         using (var md5Hash = MD5.Create())
            for (int i = 1;; ++i) if (HashStartWithZeros(md5Hash, _secret + i, leadingZerosCount)) return i.ToString();
      }

      private bool HashStartWithZeros(MD5 md5Hash, string input, int leadingZerosCount)
      {
         var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

         for (int i = 0; i < leadingZerosCount / 2; ++i) if (data[i] != 0) return false;

         var rest = leadingZerosCount % 2;
         if (rest > 0) return data[leadingZerosCount / 2] < 16;

         return true;
      }
   }
}