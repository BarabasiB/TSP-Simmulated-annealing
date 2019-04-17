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
            List<Point> points = GeneratePoints(10);
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
    }
}
