using System;
using System.Linq;
using AoC;

namespace AoC2017.Day03
{
   public class Problem03 : IProblem
   {
      public string SolvePart1()
      {
         var m = new Matrix();
         var filler = new MatrixFiller(m);
         filler.Fill1(5);
         m.Print();
         return string.Empty;
      }

      public string SolvePart2()
      {
         return string.Empty;
      }
   }

   public class Matrix
   {
      private const int N = 10;
      private const int K = N / 2;

      private readonly int[][] _space;

      public Matrix()
      {
         _space = new int[N][];
         Enumerable.Range(0, N).ForEach(i => _space[i] = new int[N]);
         Enumerable.Range(0, N).ForEach(i => Enumerable.Range(0, N).ForEach(j => _space[i][j] = 0));
      }

      public void Set(Point p, int value)
      {
         p = Map(p);
         _space[p.X][p.Y] = value;
      }

      public int Get(Point p)
      {
         p = Map(p);
         return _space[p.X][p.Y];
      }

      private Point Map(Point p)
      {
         return new Point(K - p.Y, K - p.X);
      }

      public void Print()
      {
         for (int i = 0; i < N; i++)
         {
            for (int j = 0; j < N; j++)
            {
               Console.Write(_space[i][j]);
               Console.Write(" ");
            }

            Console.WriteLine();
         }
      }
   }

   public class MatrixFiller
   {
      private readonly Matrix _matrix;
      private Point _current = new Point(0, 0);
      private int _layer = 0;
      private Point _direction = Left;

      private static Point Right { get; } = new Point(1, 0);
      private static Point Left { get; } = new Point(-1, 0);
      private static Point Up { get; } = new Point(0, 1);
      private static Point Down { get; } = new Point(0, -1);

      public MatrixFiller(Matrix matrix)
      {
         _matrix = matrix;
      }

      public void Fill1(int max)
      {
         _matrix.Set(_current, 1);
         Enumerable.Range(0, max).ForEach(Step);
      }

      private void Step(int i)
      {
         var currentDirection = _direction;
         if (_current.X == _layer && _current.Y == -_layer)
         {
            ++_layer;
            _direction = Up;
         }
         else if (_current.X == _layer && _current.Y == _layer)
         {
            _direction = Left;
         }
         else if (_current.X == -_layer && _current.Y == _layer)
         {
            _direction = Down;
         }
         else if (_current.X == -_layer && _current.Y == -_layer)
         {
            _direction = Right;
         }

         _current += currentDirection;
         _matrix.Set(_current, i);
      }
   }

   public class Point
   {
      public Point(int x, int y)
      {
         X = x;
         Y = y;
      }

      public int X { get; }
      public int Y { get; }

      public static Point operator +(Point p, int n)
      {
         return new Point(p.X + n, p.Y + n);
      }

      public static Point operator +(Point p1, Point p2)
      {
         return new Point(p1.X + p2.X, p1.Y + p2.Y);
      }
   }
}