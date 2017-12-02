using System;
using System.Collections.Generic;
using System.Linq;
using AoC;

namespace AoC2015.Day03
{
   public class Problem03 : IProblem
   {
      private readonly Dictionary<char, Point> _directionMap = new Dictionary<char, Point>
      {
         { '^', Directions.Up },
         { 'v', Directions.Down },
         { '<', Directions.Left },
         { '>', Directions.Right }
      };
      private readonly List<Action<City>> _actions;

      public Problem03()
      {
         _actions = new Data03().Part1().Select(c => new Action<City>(city => city.Move(_directionMap[c]))).ToList();
      }

      public string SolvePart1()
      {
         var city = new City();
         _actions.ForEach(a => a(city));
         return city.Houses.Count.ToString();
      }

      public string SolvePart2()
      {
         var santa = new City();
         _actions.Every(2).ForEach(a => a(santa));

         var robo = new City();
         _actions.Skip(1).Every(2).ForEach(a => a(robo));

         return santa.Houses.Union(robo.Houses).Count().ToString();
      }
   }

   public class City
   {
      private Point _current = new Point(0, 0);

      public City()
      {
         Houses = new HashSet<Point> { _current };
      }

      public HashSet<Point> Houses { get; }

      public void Move(Point direction)
      {
         Houses.Add(_current += direction);
      }
   }

   public static class Directions
   {
      public static Point Up { get; } = new Point(0, 1);
      public static Point Down { get; } = new Point(0, -1);
      public static Point Left { get; } = new Point(-1, 0);
      public static Point Right { get; } = new Point(1, 0);
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

      public static Point operator +(Point p1, Point p2)
      {
         return new Point(p1.X + p2.X, p1.Y + p2.Y);
      }

      public override int GetHashCode()
      {
         unchecked
         {
            return (X * 397) ^ Y;
         }
      }

      public override bool Equals(object obj)
      {
         var point = obj as Point;
         return point != null && Equals(point);
      }

      protected bool Equals(Point other)
      {
         return X == other.X && Y == other.Y;
      }
   }
}