using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPoints = 30;
            List<Point> points = GeneratePoints(numberOfPoints);
        }

        private static List<Point> GeneratePoints(int size)
        {
            List<Point> points = new List<Point>();
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                points.Add(new Point
                {
                    X = rand.NextDouble() * 100,
                    Y = rand.NextDouble() * 100
                });
            }
            return points;
        }

        private static int RandomPosition(int size)
        {
            Random rand = new Random();
            return rand.Next(0, size);
        }
    }
}
